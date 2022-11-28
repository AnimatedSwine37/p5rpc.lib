using p5rpc.inputhook.interfaces;
using p5rpc.lib.interfaces;
using p5rpc.lib.tester.Configuration;
using p5rpc.lib.tester.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using static p5rpc.inputhook.interfaces.Inputs;
using static p5rpc.lib.interfaces.FlowStruct;
using static p5rpc.lib.interfaces.Sequence;

namespace p5rpc.lib.tester
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : ModBase // <= Do not Remove.
    {
        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private readonly IModLoader _modLoader;

        /// <summary>
        /// Provides access to the Reloaded.Hooks API.
        /// </summary>
        /// <remarks>This is null if you remove dependency on Reloaded.SharedLib.Hooks in your mod.</remarks>
        private readonly IReloadedHooks? _hooks;

        /// <summary>
        /// Provides access to the Reloaded logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Entry point into the mod, instance that created this class.
        /// </summary>
        private readonly IMod _owner;

        /// <summary>
        /// Provides access to this mod's configuration.
        /// </summary>
        private Config _configuration;

        /// <summary>
        /// The configuration of the currently executing mod.
        /// </summary>
        private readonly IModConfig _modConfig;

        private IInputHook _inputHook;

        private IP5RLib _p5rLib;

        private IFlowCaller _flowCaller;

        public Mod(ModContext context)
        {
            _modLoader = context.ModLoader;
            _hooks = context.Hooks;
            _logger = context.Logger;
            _owner = context.Owner;
            _configuration = context.Configuration;
            _modConfig = context.ModConfig;


            // For more information about this template, please see
            // https://reloaded-project.github.io/Reloaded-II/ModTemplate/

            // If you want to implement e.g. unload support in your mod,
            // and some other neat features, override the methods in ModBase.

            // TODO: Implement some mod logic
            Utils.Initialise(_logger);
            var inputController = _modLoader.GetController<IInputHook>();
            if (inputController == null || !inputController.TryGetTarget(out _inputHook))
            {
                Utils.LogError("Could not get input hook, please make sure you have p5rpc.inputhook installed.");
                return;
            }

            var libController = _modLoader.GetController<IP5RLib>();
            if (libController == null || !libController.TryGetTarget(out _p5rLib))
            {
                Utils.LogError("Could not get p5r library, please make sure you have p5rpc.lib installed.");
                return;
            }

            _flowCaller = _p5rLib.FlowCaller;

            _inputHook.OnInput += InputHappened;

            _p5rLib.Sequencer.SequenceChanged += SequenceChanged;
            _p5rLib.Sequencer.EventStarted += EventStarted;
        }

        private void EventStarted(EventInfo eventInfo)
        {
            Utils.Log($"You are now in event {eventInfo}");
        }

        private unsafe void SequenceChanged(SequenceInfo sequence)
        {
            Utils.Log($"The sequence changed to {sequence}");
        }

        private void InputHappened(List<Key> inputs)
        {
            if(inputs.Contains(Key.F5))
            {
                _flowCaller.CALL_FIELD(1, 3, 0, 0);
            } 
            // Testing inputs and outputs
            if(inputs.Contains(Key.F6))
            {
                float x = _flowCaller.FLD_CAMERA_GET_X_POS();
                float y = _flowCaller.FLD_CAMERA_GET_Y_POS();
                float z = _flowCaller.FLD_CAMERA_GET_Z_POS();
                Utils.Log($"The camera is at {x}, {y}, {z}");

                Utils.Log($"sin(90) = {_flowCaller.SIN(90)}");
                Utils.Log($"sin(0) = {_flowCaller.SIN(0)}");

                Utils.Log($"The time is {_flowCaller.GET_TIME()}");
                Utils.Log($"The day of week is {_flowCaller.GET_DAYOFWEEK()}");
                Utils.Log($"The month is {_flowCaller.GET_MONTH()}");
            }
        }

        #region Standard Overrides
        public override void ConfigurationUpdated(Config configuration)
        {
            // Apply settings from configuration.
            // ... your code here.
            _configuration = configuration;
            _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
        }
        #endregion

        #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Mod() { }
#pragma warning restore CS8618
        #endregion
    }
}