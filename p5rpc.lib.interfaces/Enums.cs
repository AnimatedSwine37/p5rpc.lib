using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5rpc.lib.interfaces
{
    /// <summary>
    /// A class containing many useful enums for p5rpc
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// A confidant in the game
        /// </summary>
        public enum Confidant
        {
            None,
            Igor,
            Morgana,
            Makoto,
            Haru,
            Yusuke,
            Sojiro,
            Ann,
            Ryuji,
            Akechi,
            Futaba,
            Chihaya,
            Twins,
            Iwai,
            Takemi,
            Kawakami,
            Ohya,
            Shinya,
            Hifumi,
            Mishima,
            Yoshida,
            Sae,
            World,
            Makoto_Friendzone,
            Haru_Friendzone,
            Ann_Friendzone,
            Futaba_Friendzone,
            Chihaya_Friendzone,
            Takemi_Friendzone,
            Kawakami_Friendzone,
            Ohya_Friendzone,
            Hifumi_Friendzone,
            Sae_Friendzone,
            Kasumi,
            Kasumi_Friendzone,
            Maruki,
            Sumire,
            Sumire_Friendzone,
        }

        /// <summary>
        /// A Persona in the game
        /// </summary>
        public enum Persona
        {
            _,
            Metatron,
            Beelzebub,
            Cu_Chulainn,
            Jack_o_Lantern,
            Jack_Frost,
            Pixie,
            Cerberus,
            Lilim,
            Eligor,
            Odin,
            Hua_Po,
            Decarabia,
            Mara,
            Ose,
            Thor,
            Unicorn,
            Uriel,
            Sarasvati,
            Valkyrie,
            Yaksini,
            Ganesha,
            Anubis,
            Mot,
            Raphael,
            Scathach,
            High_Pixie,
            Barong,
            Girimehkala,
            King_Frost,
            Narcissus,
            Isis,
            Lamia,
            Legion,
            Rakshasa,
            Mokoi,
            Forneus,
            Setanta,
            Titania,
            Incubus,
            Oni,
            Lilith,
            Rangda,
            Makami,
            Parvati,
            Gabriel,
            Zaou_Gongen,
            Alice,
            Kali,
            Kurama_Tengu,
            Oberon,
            Shiki_Ouji,
            Yamata_no_Orochi,
            Orobas,
            Hanuman,
            Archangel,
            Obariyon,
            Queen_Mab,
            Sandalphon,
            Abaddon,
            Shiisaa,
            Sandman,
            Belial,
            Leanan_Sidhe,
            Cybele,
            Chernobog,
            Flauros,
            Ippon_Datara,
            Orthrus,
            Succubus,
            Mothman,
            RESERVE,
            Dominion,
            Nekomata,
            Black_Frost,
            Arahabaki,
            Angel,
            Skadi,
            Kikuri_Hime,
            Chi_You,
            Power,
            Inugami,
            Nebiros,
            RESERVE_0083,
            Slime,
            Anzu,
            Yatagarasu,
            Yoshitsune,
            Take_Minakata,
            Ame_no_Uzume,
            Kushinada,
            Kumbhanda,
            Ongyo_Ki,
            Kin_Ki,
            Sui_Ki,
            Fuu_Ki,
            Jatayu,
            Kaiwan,
            Kelpie,
            Thoth,
            Dionysus,
            Apsaras,
            Andras,
            RESERVE_0103,
            Koropokguru,
            Koppa_Tengu,
            Regent,
            Queens_Necklace,
            Stone_of_Scone,
            Koh_i_Noor,
            Orlov,
            Emperors_Amulet,
            Hope_Diamond,
            Crystal_Skull,
            Orichalcum,
            RESERVE_0115,
            RESERVE_0116,
            RESERVE_0117,
            RESERVE_0118,
            RESERVE_0119,
            RESERVE_0120,
            Mandrake,
            Baal,
            Dakini,
            Silky,
            Bugs,
            Black_Ooze,
            Bicorn,
            Mithras,
            Sudama,
            Kodama,
            Agathion,
            Onmoraki,
            Nue,
            Pisaca,
            Melchizedek,
            Baphomet,
            Raja_Naga,
            Naga,
            Garuda,
            Moloch,
            Norn,
            Belphegor,
            Berith,
            Choronzon,
            RESERVE_0145,
            RESERVE_0146,
            RESERVE_0147,
            RESERVE_0148,
            RESERVE_0149,
            RESERVE_0150,
            Nigi_Mitama,
            Kushi_Mitama,
            Ara_Mitama,
            Saki_Mitama,
            RESERVE_0155,
            Shiva,
            Michael,
            Asura,
            Mada,
            Mother_Harlot,
            Clotho,
            Lachesis,
            Atropos,
            Ardha,
            RESERVE_0165,
            Vishnu,
            Hariti,
            Yurlungur,
            Hecatoncheires,
            Satanael,
            RESERVE_0171,
            RESERVE_0172,
            RESERVE_0173,
            RESERVE_0174,
            RESERVE_0175,
            RESERVE_0176,
            RESERVE_0177,
            RESERVE_0178,
            RESERVE_0179,
            RESERVE_0180,
            Orpheus,
            Thanatos,
            Izanagi,
            Magatsu_Izanagi,
            Kaguya,
            Ariadne,
            Asterius,
            Tsukiyomi,
            Messiah,
            Messiah_Picaro,
            Orpheus_Picaro,
            Thanatos_Picaro,
            Izanagi_Picaro,
            M__Izanagi_Picaro,
            Kaguya_Picaro,
            Ariadne_Picaro,
            Asterius_Picaro,
            Tsukiyomi_Picaro,
            Satanael_0199,
            Arsène_Intro,
            Arsène,
            Captain_Kidd,
            Zorro,
            Carmen,
            Goemon,
            Johanna,
            Milady,
            Necronomicon,
            Robin_Hood,
            Loki,
            Satanael_0211,
            Seiten_Taisei,
            Mercurius,
            Hecate,
            Kamu_Susano_o,
            Anat,
            Astarte,
            Prometheus,
            Loki_0219,
            Arsène_0220,
            Captain_Kidd_0221,
            Zorro_0222,
            Carmen_0223,
            Goemon_0224,
            Johanna_0225,
            Milady_0226,
            Necronomicon_0227,
            Robin_Hood_0228,
            Cendrillon_Intro,
            Lucifer,
            Seiten_Taisei_0231,
            Mercurius_0232,
            Hecate_0233,
            Kamu_Susano_o_0234,
            Anat_0235,
            Astarte_0236,
            Prometheus_0237,
            Loki_0238,
            Loki_0239,
            Cendrillon,
            Vanadis,
            William,
            Diego,
            Célestine,
            Gorokichi,
            Agnes,
            Lucy,
            Al_Azif,
            Hereward,
            Ella,
            RESERVE_0251,
            Satan,
            Lucifer_0253,
            Kohryu,
            Okuninushi,
            Norn_0256,
            RESERVE_0257,
            RESERVE_0258,
            Futsunushi,
            RESERVE_0260,
            Seth,
            Ishtar,
            RESERVE_0263,
            Surt,
            Ex_Siegfried,
            Lakshmi,
            RESERVE_0267,
            RESERVE_0268,
            Ex_Belphegor,
            RESERVE_0270,
            Garuda_0271,
            Fortuna,
            Suzaku,
            Seiryu,
            Genbu,
            Byakko,
            Bishamonten,
            Koumokuten,
            Jikokuten,
            Zouchouten,
            Hell_Biker,
            Daisoujou,
            Trumpeter,
            White_Rider,
            Matador,
            Pale_Rider,
            Horus,
            RESERVE_0288,
            Attis,
            RESERVE_0290,
            RESERVE_0291,
            Sraosha,
            Berith_0293,
            RESERVE_0294,
            Mitra,
            Phoenix,
            Principality,
            Neko_Shogun,
            Vasuki,
            Ananta,
            Throne,
            RESERVE_0302,
            Quetzalcoatl,
            Red_Rider,
            Black_Rider,
            RESERVE_0306,
            Ex_Moloch,
            Pazuzu,
            Cendrillon_for_Timing,
            Slime_0310,
            Jack_o_Lantern_0311,
            Agathion_0312,
            Mandrake_0313,
            Shiisaa_0314,
            Jack_Frost_0315,
            Sudama_0316,
            Onmoraki_0317,
            Bugs_0318,
            Pixie_0319,
            Pixie_0320,
            Ardha_0321,
            RESERVE_0322,
            Asmodeus,
            Azazel,
            Baal_0325,
            Tithoes,
            Mammon,
            Leviathan,
            Samael,
            Maria,
            Vohu_Manah,
            Cait_Sith,
            Mishaguji,
            Frost_for_Challenge,
            Angels_for_the_Challenge,
            RESERVE_0336,
            RESERVE_0337,
            RESERVE_0338,
            RESERVE_0339,
            RESERVE_0340,
            RESERVE_0341,
            RESERVE_0342,
            RESERVE_0343,
            RESERVE_0344,
            RESERVE_0345,
            RESERVE_0346,
            RESERVE_0347,
            RESERVE_0348,
            RESERVE_0349,
            RESERVE_0350,
            P__Unused,
            P__Unused_0352,
            P__Unused_0353,
            P__Unused_0354,
            P__Unused_0355,
            P__Unused_0356,
            P__Unused_0357,
            P__Unused_0358,
            P__Unused_0359,
            Izanagi_no_Okami,
            Psyche,
            Athena,
            Raoul,
            Orpheus_Telos,
            Orpheus_0365,
            Izanagi_no_Okami_Pic_,
            Psyche_Picaro,
            Athena_Picaro,
            Neo_Arsène_Picaro,
            Orpheus_Telos_Picaro,
            Orpheus_Picaro_0371,
            P__Unused_0372,
            P__Unused_0373,
            P__Unused_0374,
            P__Unused_0375,
            P__Unused_0376,
            P__Unused_0377,
            P__Unused_0378,
            P__Unused_0379,
            P__Unused_0380,
            P__Unused_0381,
            P__Unused_0382,
            P__Unused_0383,
            P__Unused_0384,
            P__Unused_0385,
            P__Unused_0386,
            P__Unused_0387,
            P__Unused_0388,
            P__Unused_0389,
            P__Unused_0390,
            P__Unused_0391,
            P__Unused_0392,
            P__Unused_0393,
            P__Unused_0394,
            P__Unused_0395,
            P__Unused_0396,
            P__Unused_0397,
            P__Unused_0398,
            P__Unused_0399,
            P__Unused_0400,
            P__Unused_0401,
            P__Unused_0402,
            P__Unused_0403,
            P__Unused_0404,
            P__Unused_0405,
            P__Unused_0406,
            P__Unused_0407,
            P__Unused_0408,
            P__Unused_0409,
            P__Unused_0410,
            P__Unused_0411,
            P__Unused_0412,
            P__Unused_0413,
            P__Unused_0414,
            P__Unused_0415,
            P__Unused_0416,
            P__Unused_0417,
            P__Unused_0418,
            P__Unused_0419,
            P__Unused_0420,
            P__Unused_0421,
            P__Unused_0422,
            P__Unused_0423,
            Macabre,
            Alilat,
            Thunderbird,
            Fafnir,
            Byakhee,
            Hastur,
            Tam_Lin,
            Throne_0431,
            Surt_0432,
            Loa,
            Chimera,
            Atavaka,
            Cait_Sith_0436,
            Siegfried,
            P__Unused_0438,
            P__Unused_0439,
            Lavenzas_Kelpie,
            Lavenzas_Berith,
            Lavenzas_Inugami,
            Lavenzas_Nue,
            Lavenzas_Oni,
            Lavenzas_Anubis,
            Lavenzas_Mithras,
            Lavenzas_Ose,
            Lavenzas_Atavak,
            Lavenzas_Thor,
            Lavenzas_Lucifer,
            P__Orpheus,
            P__Izanagi,
            P__Thanatos,
            P__Messiah,
            P__Attis,
            P__Siegfried,
            P__Koryu,
            P__Kaguya,
            P__Sraosha,
            P__Yoshitsune,
            P__Izanagi_No_Okami,
            RESERVE_0462,
            RESERVE_0463,
        }

        /// <summary>
        /// A skill of a <see cref="Persona"/> or <see cref="Enemy"/>
        /// </summary>
        public enum Skill
        {
            /// <summary>
            /// BLANK
            /// </summary>
            Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0002,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0003,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0004,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0005,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0006,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0007,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0008,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0009,
            /// <summary>
            /// Light Fire dmg to one foe. Chance of inflicting Burn.
            /// </summary>
            Agi,
            /// <summary>
            /// Medium Fire dmg to one foe. Chance of inflicting Burn.
            /// </summary>
            Agilao,
            /// <summary>
            /// Heavy Fire dmg to one foe. Chance of inflicting Burn.
            /// </summary>
            Agidyne,
            /// <summary>
            /// Light Fire dmg to all foes. Chance of inflicting Burn.
            /// </summary>
            Maragi,
            /// <summary>
            /// Medium Fire dmg to all foes. Chance of inflicting Burn.
            /// </summary>
            Maragion,
            /// <summary>
            /// Heavy Fire dmg to all foes. Chance of inflicting Burn.
            /// </summary>
            Maragidyne,
            /// <summary>
            /// BLANK
            /// </summary>
            Agi_0016,
            /// <summary>
            /// BLANK
            /// </summary>
            Maragi_0017,
            /// <summary>
            /// BLANK
            /// </summary>
            Fire_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Raging_Flames,
            /// <summary>
            /// Light Ice dmg to one foe. Chance of inflicting Freeze.
            /// </summary>
            Bufu,
            /// <summary>
            /// Medium Ice dmg to one foe. Chance of inflicting Freeze.
            /// </summary>
            Bufula,
            /// <summary>
            /// Heavy Ice dmg to one foe. Chance of inflicting Freeze.
            /// </summary>
            Bufudyne,
            /// <summary>
            /// Light Ice dmg to all foes. Chance of inflicting Freeze.
            /// </summary>
            Mabufu,
            /// <summary>
            /// Medium Ice dmg to all foes. Chance of inflicting Freeze.
            /// </summary>
            Mabufula,
            /// <summary>
            /// Heavy Ice dmg to all foes. Chance of inflicting Freeze.
            /// </summary>
            Mabufudyne,
            /// <summary>
            /// BLANK
            /// </summary>
            Bufu_0026,
            /// <summary>
            /// BLANK
            /// </summary>
            Mabufu_0027,
            /// <summary>
            /// BLANK
            /// </summary>
            Snow_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Megidolaon,
            /// <summary>
            /// Light Wind dmg to one foe.
            /// </summary>
            Garu,
            /// <summary>
            /// Medium Wind dmg to one foe.
            /// </summary>
            Garula,
            /// <summary>
            /// Heavy Wind dmg to one foe.
            /// </summary>
            Garudyne,
            /// <summary>
            /// Light Wind dmg to all foes.
            /// </summary>
            Magaru,
            /// <summary>
            /// Medium Wind dmg to all foes.
            /// </summary>
            Magarula,
            /// <summary>
            /// Heavy Wind dmg to all foes.
            /// </summary>
            Magarudyne,
            /// <summary>
            /// BLANK
            /// </summary>
            Garu_0036,
            /// <summary>
            /// BLANK
            /// </summary>
            Gale_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Bless_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Curse_Ball,
            /// <summary>
            /// Light Elec dmg to one foe. Chance of inflicting Shock.
            /// </summary>
            Zio,
            /// <summary>
            /// Medium Elec dmg to one foe. Chance of inflicting Shock.
            /// </summary>
            Zionga,
            /// <summary>
            /// Heavy Elec dmg to one foe. Chance of inflicting Shock.
            /// </summary>
            Ziodyne,
            /// <summary>
            /// Light Elec dmg to all foes. Chance of inflicting Shock.
            /// </summary>
            Mazio,
            /// <summary>
            /// Medium Elec dmg to all foes. Chance of inflicting Shock.
            /// </summary>
            Mazionga,
            /// <summary>
            /// Heavy Elec dmg to all foes. Chance of inflicting Shock.
            /// </summary>
            Maziodyne,
            /// <summary>
            /// BLANK
            /// </summary>
            Zio_0046,
            /// <summary>
            /// BLANK
            /// </summary>
            Mazio_0047,
            /// <summary>
            /// BLANK
            /// </summary>
            Volt_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Make_it_Rain,
            /// <summary>
            /// Low chance of Bless insta-kill to one foe.
            /// </summary>
            Hama,
            /// <summary>
            /// Medium chance of Bless insta-kill to one foe.
            /// </summary>
            Hamaon,
            /// <summary>
            /// Low chance of Bless insta-kill to all foes.
            /// </summary>
            Mahama,
            /// <summary>
            /// Medium chance of Bless insta-kill to all foes.
            /// </summary>
            Mahamaon,
            /// <summary>
            /// Light Bless dmg to one foe.
            /// </summary>
            Kouha,
            /// <summary>
            /// Medium Bless dmg to one foe.
            /// </summary>
            Kouga,
            /// <summary>
            /// Heavy Bless dmg to one foe.
            /// </summary>
            Kougaon,
            /// <summary>
            /// Light Bless dmg to all foes.
            /// </summary>
            Makouha,
            /// <summary>
            /// Medium Bless dmg to all foes.
            /// </summary>
            Makouga,
            /// <summary>
            /// Heavy Bless dmg to all foes.
            /// </summary>
            Makougaon,
            /// <summary>
            /// Low chance of Curse insta-kill to one foe.
            /// </summary>
            Mudo,
            /// <summary>
            /// Medium chance of Curse insta-kill to one foe.
            /// </summary>
            Mudoon,
            /// <summary>
            /// Low chance of Curse insta-kill to all foes.
            /// </summary>
            Mamudo,
            /// <summary>
            /// Medium chance of Curse insta-kill to all foes.
            /// </summary>
            Mamudoon,
            /// <summary>
            /// Light Curse dmg to one foe.
            /// </summary>
            Eiha,
            /// <summary>
            /// Medium Curse dmg to one foe.
            /// </summary>
            Eiga,
            /// <summary>
            /// Heavy Curse dmg to one foe.
            /// </summary>
            Eigaon,
            /// <summary>
            /// Light Curse dmg to all foes.
            /// </summary>
            Maeiha,
            /// <summary>
            /// Medium Curse dmg to all foes.
            /// </summary>
            Maeiga,
            /// <summary>
            /// Heavy Curse dmg to all foes.
            /// </summary>
            Maeigaon,
            /// <summary>
            /// Medium Almighty dmg to all foes.
            /// </summary>
            Megido,
            /// <summary>
            /// Heavy Almighty dmg to all foes.
            /// </summary>
            Megidola,
            /// <summary>
            /// Severe Almighty dmg to all foes.
            /// </summary>
            Megidolaon_0072,
            /// <summary>
            /// Light Nuke dmg to one foe.
            /// </summary>
            Frei,
            /// <summary>
            /// Medium Nuke dmg to one foe.
            /// </summary>
            Freila,
            /// <summary>
            /// Heavy Nuke dmg to one foe.
            /// </summary>
            Freidyne,
            /// <summary>
            /// Light Nuke dmg to all foes.
            /// </summary>
            Mafrei,
            /// <summary>
            /// Medium Nuke dmg to all foes.
            /// </summary>
            Mafreila,
            /// <summary>
            /// Heavy Nuke dmg to all foes.
            /// </summary>
            Mafreidyne,
            /// <summary>
            /// BLANK
            /// </summary>
            Nuke_Ball,
            /// <summary>
            /// High chance of Dizzy to one foe.
            /// </summary>
            Dazzler,
            /// <summary>
            /// Medium chance of Dizzy to all foes.
            /// </summary>
            Nocturnal_Flash,
            /// <summary>
            /// High chance of Confuse to one foe.
            /// </summary>
            Pulinpa,
            /// <summary>
            /// Medium chance of Confuse to all foes.
            /// </summary>
            Tentarafoo,
            /// <summary>
            /// High chance of Fear to one foe.
            /// </summary>
            Evil_Touch,
            /// <summary>
            /// Medium chance of Fear to all foes.
            /// </summary>
            Evil_Smile,
            /// <summary>
            /// High chance of Forget to one foe.
            /// </summary>
            Makajama,
            /// <summary>
            /// Medium chance of Forget to all foes.
            /// </summary>
            Makajamaon,
            /// <summary>
            /// High chance of Hunger to one foe.
            /// </summary>
            Famines_Breath,
            /// <summary>
            /// Medium chance of Hunger to all foes.
            /// </summary>
            Famines_Scream,
            /// <summary>
            /// High chance of Sleep to one foe.
            /// </summary>
            Dormina,
            /// <summary>
            /// Medium chance of Sleep to all foes.
            /// </summary>
            Lullaby,
            /// <summary>
            /// High chance of Rage to one foe.
            /// </summary>
            Taunt,
            /// <summary>
            /// Medium chance of Rage to all foes.
            /// </summary>
            Wage_War,
            /// <summary>
            /// High chance of Despair to one foe.
            /// </summary>
            Ominous_Words,
            /// <summary>
            /// Medium chance of Despair to all foes.
            /// </summary>
            Abysmal_Surge,
            /// <summary>
            /// High chance of Brainwash to one foe.
            /// </summary>
            Marin_Karin,
            /// <summary>
            /// Medium chance of Brainwash to all foes.
            /// </summary>
            Brain_Jack,
            /// <summary>
            /// High chance of Mouse to one foe.
            /// </summary>
            Trapped_Rat,
            /// <summary>
            /// BLANK
            /// </summary>
            Psy_Ball,
            /// <summary>
            /// Medium Almighty dmg to all.
            /// </summary>
            Self_destruct,
            /// <summary>
            /// Medium Almighty dmg to all.
            /// </summary>
            Self_destruct_0101,
            /// <summary>
            /// Heavy Almighty dmg to all.
            /// </summary>
            Self_destruct_0102,
            /// <summary>
            /// Drains HP from one foe.
            /// </summary>
            Life_Drain,
            /// <summary>
            /// Drains SP from one foe.
            /// </summary>
            Spirit_Drain,
            /// <summary>
            /// Drains high amount of HP from one foe.
            /// </summary>
            Life_Leech,
            /// <summary>
            /// Drains high amount of SP from one foe.
            /// </summary>
            Spirit_Leech,
            /// <summary>
            /// BLANK
            /// </summary>
            Spirit_Drain_0107,
            /// <summary>
            /// BLANK
            /// </summary>
            NOT_USED,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0109,
            /// <summary>
            /// Increases chance of inflicting ailments to one foe.
            /// </summary>
            Foul_Breath,
            /// <summary>
            /// Increases chance of inflicting ailments to all.
            /// </summary>
            Stagnant_Air,
            /// <summary>
            /// High chance of Rage to one foe.
            /// </summary>
            Reverse_Rub,
            /// <summary>
            /// Insta-kills foes inflicted with Fear.
            /// </summary>
            Ghastly_Wail,
            /// <summary>
            /// BLANK
            /// </summary>
            NOT_USED_0114,
            /// <summary>
            /// BLANK
            /// </summary>
            Drain,
            /// <summary>
            /// BLANK
            /// </summary>
            Megidola_0116,
            /// <summary>
            /// BLANK
            /// </summary>
            Launch,
            /// <summary>
            /// BLANK
            /// </summary>
            Special_Fireworks,
            /// <summary>
            /// BLANK
            /// </summary>
            Drift,
            /// <summary>
            /// Severe Fire dmg to one foe. Chance of inflicting Burn.
            /// </summary>
            Inferno,
            /// <summary>
            /// Severe Fire dmg to all foes. Chance of inflicting Burn.
            /// </summary>
            Blazing_Hell,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_Burn,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_Burn,
            /// <summary>
            /// BLANK
            /// </summary>
            High_Burn,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_Freeze,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_Freeze,
            /// <summary>
            /// BLANK
            /// </summary>
            High_Freeze,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_Shock,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_Shock,
            /// <summary>
            /// Severe Ice dmg to one foe. Chance of inflicting Freeze.
            /// </summary>
            Diamond_Dust,
            /// <summary>
            /// Severe Ice dmg to all foes. Chance of inflicting Freeze.
            /// </summary>
            Ice_Age,
            /// <summary>
            /// BLANK
            /// </summary>
            High_Shock,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_Dizzy,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_Dizzy,
            /// <summary>
            /// BLANK
            /// </summary>
            High_Dizzy,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_Confuse,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_Confuse,
            /// <summary>
            /// BLANK
            /// </summary>
            High_Confuse,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_Fear,
            /// <summary>
            /// Severe Wind dmg to one foe.
            /// </summary>
            Panta_Rhei,
            /// <summary>
            /// Severe Wind dmg to all foes.
            /// </summary>
            Vacuum_Wave,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_Fear,
            /// <summary>
            /// BLANK
            /// </summary>
            High_Fear,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_Forget,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_Forget,
            /// <summary>
            /// BLANK
            /// </summary>
            High_Forget,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_Brainwash,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_Brainwash,
            /// <summary>
            /// BLANK
            /// </summary>
            High_Brainwash,
            /// <summary>
            /// Severe Elec dmg to one foe. Chance of inflicting Shock.
            /// </summary>
            Thunder_Reign,
            /// <summary>
            /// Severe Elec dmg to all foes. Chance of inflicting Shock.
            /// </summary>
            Wild_Thunder,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_Sleep,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_Sleep,
            /// <summary>
            /// BLANK
            /// </summary>
            High_Sleep,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_Rage,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_Rage,
            /// <summary>
            /// BLANK
            /// </summary>
            High_Rage,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_Despair,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_Despair,
            /// <summary>
            /// Bless attack that reduces HP of one foe by 50%.
            /// </summary>
            Divine_Judgment,
            /// <summary>
            /// High chance of Bless insta-kill to all foes.
            /// </summary>
            Samsara,
            /// <summary>
            /// BLANK
            /// </summary>
            High_Despair,
            /// <summary>
            /// BLANK
            /// </summary>
            Low_All_Ail,
            /// <summary>
            /// BLANK
            /// </summary>
            Mid_All_Ail,
            /// <summary>
            /// BLANK
            /// </summary>
            High_All_Ail,
            /// <summary>
            /// BLANK
            /// </summary>
            Adam_Skill__,
            /// <summary>
            /// BLANK
            /// </summary>
            Revitalize_Soul,
            /// <summary>
            /// BLANK
            /// </summary>
            Grand_Palm,
            /// <summary>
            /// BLANK
            /// </summary>
            Full_Force,
            /// <summary>
            /// Curse attack that reduces HP of one foe by 50%.
            /// </summary>
            Demonic_Decree,
            /// <summary>
            /// High chance of Curse insta-kill to all foes.
            /// </summary>
            Die_For_Me,
            /// <summary>
            /// Activates Masukunda, Marakunda, and Matarunda.
            /// </summary>
            Support_Plus__,
            /// <summary>
            /// Activates Masukunda and Marakunda.
            /// </summary>
            Support_Plus___0173,
            /// <summary>
            /// Activates Masukunda.
            /// </summary>
            Support_Plus___0174,
            /// <summary>
            /// Increases activation of Moral Support.
            /// </summary>
            Support_Rate_Up,
            /// <summary>
            /// Severe Nuke dmg to one foe.
            /// </summary>
            Atomic_Flare,
            /// <summary>
            /// Severe Nuke dmg to all foes.
            /// </summary>
            Cosmic_Flare,
            /// <summary>
            /// BLANK
            /// </summary>
            Mindfulness,
            /// <summary>
            /// BLANK
            /// </summary>
            Wakefulness,
            /// <summary>
            /// Severe Almighty dmg to one foe.
            /// </summary>
            Black_Viper,
            /// <summary>
            /// Severe Almighty dmg to all foes.
            /// </summary>
            Morning_Star,
            /// <summary>
            /// Severe Almighty dmg to all foes.
            /// </summary>
            Abyssal_Eye,
            /// <summary>
            /// Restores med amount of HP and increases Attack for one ally for 3 turns.
            /// </summary>
            Champions_Cup,
            /// <summary>
            /// Forms a barrier that can absorb one attack (except Almighty).
            /// </summary>
            Bleeding_Dry_Brush,
            /// <summary>
            /// Increases Defense for all allies for 3 turns.
            /// </summary>
            Vault_Guardian,
            /// <summary>
            /// Cures all non-special ailments for all allies.
            /// </summary>
            Wings_of_Wisdom,
            /// <summary>
            /// Next magical attack deals over double the damage for one ally.
            /// </summary>
            Presidents_Insight,
            /// <summary>
            /// Increases Agility for all allies for 3 turns.
            /// </summary>
            Gamblers_Foresight,
            /// <summary>
            /// Next physical attack deals over double the damage for one ally.
            /// </summary>
            Tyrants_Will,
            /// <summary>
            /// Light Psy dmg to one foe.
            /// </summary>
            Psi,
            /// <summary>
            /// Medium Psy dmg to one foe.
            /// </summary>
            Psio,
            /// <summary>
            /// Heavy Psy dmg to one foe.
            /// </summary>
            Psiodyne,
            /// <summary>
            /// Light Psy dmg to all foes.
            /// </summary>
            Mapsi,
            /// <summary>
            /// Medium Psy dmg to all foes.
            /// </summary>
            Mapsio,
            /// <summary>
            /// Heavy Psy dmg to all foes.
            /// </summary>
            Mapsiodyne,
            /// <summary>
            /// BLANK
            /// </summary>
            Attack_Position,
            /// <summary>
            /// Severe Psy dmg to one foe.
            /// </summary>
            Psycho_Force,
            /// <summary>
            /// Severe Psy dmg to all foes.
            /// </summary>
            Psycho_Blast,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0199,
            /// <summary>
            /// Light Phys dmg to one foe.
            /// </summary>
            Lunge,
            /// <summary>
            /// Heavy Phys dmg to one foe.
            /// </summary>
            Assault_Dive,
            /// <summary>
            /// Severe Phys dmg to one foe.
            /// </summary>
            Megaton_Raid,
            /// <summary>
            /// Colossal Phys dmg to one foe.
            /// </summary>
            Gods_Hand,
            /// <summary>
            /// BLANK
            /// </summary>
            Lunge_0204,
            /// <summary>
            /// Miniscule Phys dmg to one foe with high chance of Critical.
            /// </summary>
            Lucky_Punch,
            /// <summary>
            /// Medium Phys dmg to one foe with high chance of Critical.
            /// </summary>
            Miracle_Punch,
            /// <summary>
            /// Light Phys dmg to one foe 1-3 times.
            /// </summary>
            Kill_Rush,
            /// <summary>
            /// Light Phys dmg to one foe 3-4 times.
            /// </summary>
            Gatling_Blow,
            /// <summary>
            /// BLANK
            /// </summary>
            Piercing_Strike,
            /// <summary>
            /// Light Phys dmg to one foe.
            /// </summary>
            Cleave,
            /// <summary>
            /// Medium Phys dmg to one foe. Powers up after a Baton Pass.
            /// </summary>
            Giant_Slice,
            /// <summary>
            /// Colossal Phys dmg to one foe.
            /// </summary>
            Brave_Blade,
            /// <summary>
            /// Colossal Phys dmg to one foe with high chance of Critical.
            /// </summary>
            Sword_Dance,
            /// <summary>
            /// Revives all fallen allies to full HP.
            /// </summary>
            Holy_Benevolence,
            /// <summary>
            /// Light Phys dmg to all foes 8 times.
            /// </summary>
            Hassou_Tobi,
            /// <summary>
            /// Medium Phys dmg to one foe 3 times with high Accuracy.
            /// </summary>
            Ayamur,
            /// <summary>
            /// Severe Phys dmg to one foe. Medium chance of Fear.
            /// </summary>
            Death_Scythe,
            /// <summary>
            /// BLANK
            /// </summary>
            UNUSED,
            /// <summary>
            /// BLANK
            /// </summary>
            NOT_USED_0219,
            /// <summary>
            /// Medium Phys dmg to one foe. Powers up when surrounded.
            /// </summary>
            Cornered_Fang,
            /// <summary>
            /// Heavy Phys dmg to one foe. Powers up after a Baton Pass.
            /// </summary>
            Rising_Slash,
            /// <summary>
            /// Severe Phys dmg to one foe. Powers up after a Baton Pass.
            /// </summary>
            Deadly_Fury,
            /// <summary>
            /// BLANK
            /// </summary>
            Nuclear_Crush,
            /// <summary>
            /// Medium Gun dmg to one foe.
            /// </summary>
            Snap,
            /// <summary>
            /// Light Gun dmg to all foes 3 times.
            /// </summary>
            Triple_Down,
            /// <summary>
            /// Severe Gun dmg to one foe with high chance of Critical.
            /// </summary>
            One_shot_Kill,
            /// <summary>
            /// Severe Gun dmg to all foes.
            /// </summary>
            Riot_Gun,
            /// <summary>
            /// Light Gun dmg to one foe 2 times.
            /// </summary>
            Double_Shot,
            /// <summary>
            /// BLANK
            /// </summary>
            Origin_Light,
            /// <summary>
            /// Medium Phys dmg to all foes.
            /// </summary>
            Vajra_Blast,
            /// <summary>
            /// Severe Phys dmg to all foes.
            /// </summary>
            Vorpal_Blade,
            /// <summary>
            /// BLANK
            /// </summary>
            NOT_USED_0232,
            /// <summary>
            /// BLANK
            /// </summary>
            NOT_USED_0233,
            /// <summary>
            /// BLANK
            /// </summary>
            NOT_USED_0234,
            /// <summary>
            /// Medium Phys dmg to all foes.
            /// </summary>
            Vicious_Strike,
            /// <summary>
            /// Heavy Phys dmg to all foes.
            /// </summary>
            Heat_Wave,
            /// <summary>
            /// Colossal Phys dmg to all foes.
            /// </summary>
            Gigantomachia,
            /// <summary>
            /// BLANK
            /// </summary>
            Swirling_Psychokinesis,
            /// <summary>
            /// BLANK
            /// </summary>
            Tyrants_Purge,
            /// <summary>
            /// BLANK
            /// </summary>
            Mass_Ball,
            /// <summary>
            /// Light Phys dmg to all foes 1-3 times.
            /// </summary>
            Rampage,
            /// <summary>
            /// Miniscule Phys dmg to all foes 2-4 times.
            /// </summary>
            Swift_Strike,
            /// <summary>
            /// Medium Phys dmg to all foes 1-2 times.
            /// </summary>
            Deathbound,
            /// <summary>
            /// Medium Phys dmg to all foes 1-3 times.
            /// </summary>
            Agneyastra,
            /// <summary>
            /// BLANK
            /// </summary>
            NOT_USED_0245,
            /// <summary>
            /// BLANK
            /// </summary>
            Regeneration,
            /// <summary>
            /// Enemy-only Skill
            /// </summary>
            Rising_Slash_0247,
            /// <summary>
            /// Enemy-only Skill
            /// </summary>
            Deadly_Fury_0248,
            /// <summary>
            /// BLANK
            /// </summary>
            Tyrants_Judgement,
            /// <summary>
            /// Light Phys dmg to one foe 2 times.
            /// </summary>
            Double_Fangs,
            /// <summary>
            /// Medium Phys dmg to one foe.
            /// </summary>
            Power_Slash,
            /// <summary>
            /// BLANK
            /// </summary>
            Shapeless_Guard,
            /// <summary>
            /// Miniscule Phys dmg to one foe 3-5 times.
            /// </summary>
            Tempest_Slash,
            /// <summary>
            /// Medium Phys dmg to one foe 2-3 times.
            /// </summary>
            Myriad_Slashes,
            /// <summary>
            /// BLANK
            /// </summary>
            Amplify_Force,
            /// <summary>
            /// BLANK
            /// </summary>
            Amplify_Magic,
            /// <summary>
            /// BLANK
            /// </summary>
            Raining_Seeds,
            /// <summary>
            /// BLANK
            /// </summary>
            Energy_Stream,
            /// <summary>
            /// BLANK
            /// </summary>
            Flow,
            /// <summary>
            /// Medium Phys dmg to one foe. Medium chance of Dizzy.
            /// </summary>
            Sledgehammer,
            /// <summary>
            /// Medium Phys dmg to one foe. Medium chance of Confuse.
            /// </summary>
            Skull_Cracker,
            /// <summary>
            /// Light Phys dmg to one foe. Medium chance of Fear.
            /// </summary>
            Terror_Claw,
            /// <summary>
            /// Medium Phys dmg to one foe. Medium chance of Forget.
            /// </summary>
            Headbutt,
            /// <summary>
            /// Heavy Phys dmg to one foe. Medium chance of Hunger.
            /// </summary>
            Stomach_Blow,
            /// <summary>
            /// Light Gun dmg to one foe. Medium chance of Sleep.
            /// </summary>
            Dream_Needle,
            /// <summary>
            /// Medium Phys dmg to one foe. Medium chance of Rage.
            /// </summary>
            Hysterical_Slap,
            /// <summary>
            /// Heavy Phys dmg to one foe. Medium chance of Despair.
            /// </summary>
            Negative_Pile,
            /// <summary>
            /// Medium Phys dmg to one foe. Medium chance of Brainwash.
            /// </summary>
            Brain_Shake,
            /// <summary>
            /// BLANK
            /// </summary>
            Attack_0269,
            /// <summary>
            /// Medium Phys dmg to all foes. Low chance of Dizzy.
            /// </summary>
            Flash_Bomb,
            /// <summary>
            /// Medium Phys dmg to all foes. Low chance of Confuse.
            /// </summary>
            Mind_Slice,
            /// <summary>
            /// Heavy Phys dmg to all foes. Low chance of Fear.
            /// </summary>
            Bloodbath,
            /// <summary>
            /// Light Phys dmg to all foes. Low chance of Forget.
            /// </summary>
            Memory_Blow,
            /// <summary>
            /// Heavy Phys dmg to all foes. Low chance of Hunger.
            /// </summary>
            Insatiable_Strike,
            /// <summary>
            /// Medium Phys dmg to all foes. Low chance of Sleep.
            /// </summary>
            Dormin_Rush,
            /// <summary>
            /// Medium Phys dmg to all foes. Low chance of Rage.
            /// </summary>
            Oni_Kagura,
            /// <summary>
            /// Medium Phys dmg to all foes. Low chance of Despair.
            /// </summary>
            Bad_Beat,
            /// <summary>
            /// Heavy Phys dmg to all foes. Low chance of Brainwash.
            /// </summary>
            Brain_Buster,
            /// <summary>
            /// Colossal Phys dmg to one foe.
            /// </summary>
            Laevateinn,
            /// <summary>
            /// BLANK
            /// </summary>
            Handgun,
            /// <summary>
            /// BLANK
            /// </summary>
            Shotgun,
            /// <summary>
            /// BLANK
            /// </summary>
            Slingshot,
            /// <summary>
            /// BLANK
            /// </summary>
            Machine_Gun,
            /// <summary>
            /// BLANK
            /// </summary>
            Assault_Rifle,
            /// <summary>
            /// BLANK
            /// </summary>
            Revolver,
            /// <summary>
            /// BLANK
            /// </summary>
            Grenade_Launcher,
            /// <summary>
            /// BLANK
            /// </summary>
            Laser_Gun,
            /// <summary>
            /// BLANK
            /// </summary>
            Antique_Rifle,
            /// <summary>
            /// BLANK
            /// </summary>
            Tyrant_Stance,
            /// <summary>
            /// Next Phys attack will deal more than double the damage for all allies.
            /// </summary>
            Fighting_Spirit,
            /// <summary>
            /// Medium Phys dmg to all foes with high chance of Critical.
            /// </summary>
            Miracle_Rush,
            /// <summary>
            /// Decreases ATK/DEF/Accuracy/Evasion for all foes.
            /// </summary>
            Checkmate,
            /// <summary>
            /// Increases ATK/DEF/Accuracy/Evasion for all allies.
            /// </summary>
            Hyakka_Ryouran,
            /// <summary>
            /// Next magic attack will deal more than double the damage for all allies.
            /// </summary>
            High_Energy,
            /// <summary>
            /// Ultimate support effect of strengthening/healing all allies may activate in battle.
            /// </summary>
            Ultimate_Healing_Support,
            /// <summary>
            /// Erects a wall that repels Phys and Magic attacks for all allies.
            /// </summary>
            Life_Wall,
            /// <summary>
            /// Colossal Almighty dmg to one enemy. Highly effective if enemy is downed.
            /// </summary>
            Rebellion_Blade,
            /// <summary>
            /// Severe Phys dmg to one foe 2 times.
            /// </summary>
            Masquerade,
            /// <summary>
            /// Knockdown attack on all enemies (only usable when attacking first).
            /// </summary>
            Guiding_Tendril,
            /// <summary>
            /// Restores low amount of HP to one ally.
            /// </summary>
            Dia,
            /// <summary>
            /// Restores medium amount of HP to one ally.
            /// </summary>
            Diarama,
            /// <summary>
            /// Fully restores HP to one ally.
            /// </summary>
            Diarahan,
            /// <summary>
            /// Increases chance of Critical for all allies for 3 turns.
            /// </summary>
            Brave_Step,
            /// <summary>
            /// BLANK
            /// </summary>
            Maruki_Punch,
            /// <summary>
            /// Restores low amount of HP to all allies.
            /// </summary>
            Media,
            /// <summary>
            /// Restores medium amount of HP to all allies.
            /// </summary>
            Mediarama,
            /// <summary>
            /// Fully restores HP to all allies.
            /// </summary>
            Mediarahan,
            /// <summary>
            /// BLANK
            /// </summary>
            Brutal_Impact,
            /// <summary>
            /// BLANK
            /// </summary>
            Cursed_Strike,
            /// <summary>
            /// Revives one fallen ally to 50% HP.
            /// </summary>
            Recarm,
            /// <summary>
            /// Revives one fallen ally to full HP.
            /// </summary>
            Samarecarm,
            /// <summary>
            /// Fully restores HP of all allies. Reduces HP of caster to 1.
            /// </summary>
            Recarmdra,
            /// <summary>
            /// BLANK
            /// </summary>
            Sleuthing_Instinct,
            /// <summary>
            /// BLANK
            /// </summary>
            Sleuthing_Mastery,
            /// <summary>
            /// Cures all non-special ailments for one ally.
            /// </summary>
            Amrita_Drop,
            /// <summary>
            /// Cures all non-special ailments for all allies.
            /// </summary>
            Amrita_Shower,
            /// <summary>
            /// BLANK
            /// </summary>
            Holy_Strike,
            /// <summary>
            /// Fully restores HP and cures non-special ailments for all allies.
            /// </summary>
            Salvation,
            /// <summary>
            /// BLANK
            /// </summary>
            Nuclear_Strike,
            /// <summary>
            /// BLANK
            /// </summary>
            Psychokinesis_Strike,
            /// <summary>
            /// Raises own chances of being targeted by foes.
            /// </summary>
            Taunting_Aura,
            /// <summary>
            /// BLANK
            /// </summary>
            Storm_Punishment,
            /// <summary>
            /// Decreases chance of being targeted by foes.
            /// </summary>
            Concealment,
            /// <summary>
            /// BLANK
            /// </summary>
            Lightning_Punishment,
            /// <summary>
            /// Cures Dizzy/Forget/Sleep/Hunger for one ally.
            /// </summary>
            Patra,
            /// <summary>
            /// BLANK
            /// </summary>
            Punishing_Hail,
            /// <summary>
            /// Cures Confuse/Fear/Despair/Brainwash/Rage for all allies.
            /// </summary>
            Energy_Shower,
            /// <summary>
            /// Cures Confuse/Fear/Despair/Brainwash/Rage for one ally.
            /// </summary>
            Energy_Drop,
            /// <summary>
            /// Cures Burn/Freeze/Shock for one ally.
            /// </summary>
            Baisudi,
            /// <summary>
            /// Cures Dizzy/Forget/Sleep/Hunger for all allies.
            /// </summary>
            Me_Patra,
            /// <summary>
            /// Cures Burn/Freeze/Shock for all allies.
            /// </summary>
            Mabaisudi,
            /// <summary>
            /// BLANK
            /// </summary>
            Charge_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Concentrated_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Inferno_Punishment,
            /// <summary>
            /// Increases Attack for one ally for 3 turns.
            /// </summary>
            Tarukaja,
            /// <summary>
            /// Increases Defense for one ally for 3 turns.
            /// </summary>
            Rakukaja,
            /// <summary>
            /// Increases Accuracy/Evasion for one ally for 3 turns.
            /// </summary>
            Sukukaja,
            /// <summary>
            /// Increases ATK/DEF/Accuracy/Evasion for one ally.
            /// </summary>
            Heat_Riser,
            /// <summary>
            /// BLANK
            /// </summary>
            Gunfire_Punishment,
            /// <summary>
            /// Increases Attack for all allies for 3 turns.
            /// </summary>
            Matarukaja,
            /// <summary>
            /// Increases Defense for all allies for 3 turns.
            /// </summary>
            Marakukaja,
            /// <summary>
            /// Increases Accuracy/Evasion for all allies for 3 turns.
            /// </summary>
            Masukukaja,
            /// <summary>
            /// Increases ATK/DEF/Accuracy/Evasion for all allies when surrounded.
            /// </summary>
            Thermopylae,
            /// <summary>
            /// BLANK
            /// </summary>
            Guillotine_Punishment,
            /// <summary>
            /// Decreases Attack for one foe for 3 turns.
            /// </summary>
            Tarunda,
            /// <summary>
            /// Decreases Defense for one foe for 3 turns.
            /// </summary>
            Rakunda,
            /// <summary>
            /// Decreases Accuracy/Evasion for one foe for 3 turns.
            /// </summary>
            Sukunda,
            /// <summary>
            /// Decreases ATK/DEF/Accuracy/Evasion for one foe.
            /// </summary>
            Debilitate,
            /// <summary>
            /// BLANK
            /// </summary>
            Quadruple_Summon,
            /// <summary>
            /// Decreases Attack for all foes for 3 turns.
            /// </summary>
            Matarunda,
            /// <summary>
            /// Decreases Defense for all foes for 3 turns.
            /// </summary>
            Marakunda,
            /// <summary>
            /// Decreases Accuracy/Evasion for all foes for 3 turns.
            /// </summary>
            Masukunda,
            /// <summary>
            /// BLANK
            /// </summary>
            Analysis,
            /// <summary>
            /// BLANK
            /// </summary>
            Analysis_0354,
            /// <summary>
            /// Removes all stat debuffs for all allies.
            /// </summary>
            Dekunda,
            /// <summary>
            /// Removes all stat buffs for all foes.
            /// </summary>
            Dekaja,
            /// <summary>
            /// BLANK
            /// </summary>
            Explosion,
            /// <summary>
            /// BLANK
            /// </summary>
            Explosion_0358,
            /// <summary>
            /// BLANK
            /// </summary>
            Sphinx_Swipe,
            /// <summary>
            /// Next physical attack deals over double the damage.
            /// </summary>
            Charge,
            /// <summary>
            /// Next magical attack deals over double the damage.
            /// </summary>
            Concentrate,
            /// <summary>
            /// BLANK
            /// </summary>
            Nose_Dive,
            /// <summary>
            /// BLANK
            /// </summary>
            Kill_Reward_Up,
            /// <summary>
            /// BLANK
            /// </summary>
            Guard_Reward_Up,
            /// <summary>
            /// Increases chance of Critical for one ally for 3 turns.
            /// </summary>
            Rebellion,
            /// <summary>
            /// Increases chance of Critical for all for 3 turns.
            /// </summary>
            Revolution,
            /// <summary>
            /// BLANK
            /// </summary>
            Make_it_Rain_0367,
            /// <summary>
            /// BLANK
            /// </summary>
            Special_Guards,
            /// <summary>
            /// BLANK
            /// </summary>
            Fake_Artists_Grace,
            /// <summary>
            /// A barrier that reflects physical attacks for one ally one time.
            /// </summary>
            Tetrakarn,
            /// <summary>
            /// A barrier that reflects magical attacks for one ally one time.
            /// </summary>
            Makarakarn,
            /// <summary>
            /// A barrier that nullifies an insta-kill for all allies one time.
            /// </summary>
            Tetraja,
            /// <summary>
            /// BLANK
            /// </summary>
            Taste_of_Wrath,
            /// <summary>
            /// BLANK
            /// </summary>
            True_Fake,
            /// <summary>
            /// Negates Tetrakarn on all foes.
            /// </summary>
            Tetra_Break,
            /// <summary>
            /// Negates Makarakarn on all foes.
            /// </summary>
            Makara_Break,
            /// <summary>
            /// BLANK
            /// </summary>
            Killshot_of_Love,
            /// <summary>
            /// BLANK
            /// </summary>
            NOT_USED_0378,
            /// <summary>
            /// BLANK
            /// </summary>
            NOT_USED_0379,
            /// <summary>
            /// Adds Fire resistance to one ally for 3 turns.
            /// </summary>
            Fire_Wall,
            /// <summary>
            /// Adds Ice resistance to one ally for 3 turns.
            /// </summary>
            Ice_Wall,
            /// <summary>
            /// Adds Elec resistance to one ally for 3 turns.
            /// </summary>
            Elec_Wall,
            /// <summary>
            /// Adds Wind resistance to one ally for 3 turns.
            /// </summary>
            Wind_Wall,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0384,
            /// <summary>
            /// Negates Fire resistance of all foes. Cannot negate Fire Wall.
            /// </summary>
            Fire_Break,
            /// <summary>
            /// Negates Ice resistance of all foes. Cannot negate Ice Wall.
            /// </summary>
            Ice_Break,
            /// <summary>
            /// Negates Wind resistance of all foes. Cannot negate Wind Wall.
            /// </summary>
            Wind_Break,
            /// <summary>
            /// Negates Elec resistance of all foes. Cannot negate Elec Wall.
            /// </summary>
            Elec_Break,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0389,
            /// <summary>
            /// Guarantees escape from battle. Not all battles apply.
            /// </summary>
            Trafuri,
            /// <summary>
            /// Return to the entrance of the Metaverse.
            /// </summary>
            Traesto,
            /// <summary>
            /// BLANK
            /// </summary>
            Active_Barrier,
            /// <summary>
            /// Adds Nuke resistance to one ally for 3 turns.
            /// </summary>
            Nuke_Wall,
            /// <summary>
            /// Adds Psy resistance to one ally for 3 turns.
            /// </summary>
            Psy_Wall,
            /// <summary>
            /// Negates Nuke resistance of all foes. Cannot negate Nuke Wall.
            /// </summary>
            Nuke_Break,
            /// <summary>
            /// Negates Psy resistance of all foes. Cannot negate Psy Wall.
            /// </summary>
            Psy_Break,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0397,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0398,
            /// <summary>
            /// BLANK
            /// </summary>
            Flow_0399,
            /// <summary>
            /// BLANK
            /// </summary>
            All_out_Lv__,
            /// <summary>
            /// BLANK
            /// </summary>
            All_out_Lv___0401,
            /// <summary>
            /// BLANK
            /// </summary>
            All_out_Lv___0402,
            /// <summary>
            /// BLANK
            /// </summary>
            Emergency_Escape,
            /// <summary>
            /// BLANK
            /// </summary>
            Attack_0404,
            /// <summary>
            /// BLANK
            /// </summary>
            Down_Shot,
            /// <summary>
            /// Summon one unit.
            /// </summary>
            Summon,
            /// <summary>
            /// BLANK
            /// </summary>
            Call_for_Backup,
            /// <summary>
            /// BLANK
            /// </summary>
            Outlaw_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Barrage,
            /// <summary>
            /// BLANK
            /// </summary>
            Follow_Crush,
            /// <summary>
            /// BLANK
            /// </summary>
            Follow_Claw,
            /// <summary>
            /// BLANK
            /// </summary>
            Follow_Whip,
            /// <summary>
            /// BLANK
            /// </summary>
            Follow_Blade,
            /// <summary>
            /// BLANK
            /// </summary>
            Follow_Knuckle,
            /// <summary>
            /// BLANK
            /// </summary>
            Follow_Axe,
            /// <summary>
            /// BLANK
            /// </summary>
            Follow_Saber,
            /// <summary>
            /// BLANK
            /// </summary>
            Dispose_Item,
            /// <summary>
            /// BLANK
            /// </summary>
            Heal_Enemy,
            /// <summary>
            /// BLANK
            /// </summary>
            Death_Despair,
            /// <summary>
            /// BLANK
            /// </summary>
            Ally__Follow_Up,
            /// <summary>
            /// BLANK
            /// </summary>
            Ally__Follow_Up_0421,
            /// <summary>
            /// BLANK
            /// </summary>
            Ally__Follow_Up_0422,
            /// <summary>
            /// BLANK
            /// </summary>
            Ally__Follow_Up_0423,
            /// <summary>
            /// BLANK
            /// </summary>
            Ally__Follow_Up_0424,
            /// <summary>
            /// BLANK
            /// </summary>
            Ally__Follow_Up_0425,
            /// <summary>
            /// BLANK
            /// </summary>
            Ally__Follow_Up_0426,
            /// <summary>
            /// BLANK
            /// </summary>
            Power_Up_Enemy,
            /// <summary>
            /// BLANK
            /// </summary>
            Power_Up_Enemy_0428,
            /// <summary>
            /// BLANK
            /// </summary>
            Power_Up_Enemy_0429,
            /// <summary>
            /// Gives ability to view the attribute affinities of one foe.
            /// </summary>
            Steal_Info,
            /// <summary>
            /// Increases Attack for all allies for 3 turns.
            /// </summary>
            Sup_Matarukaja,
            /// <summary>
            /// Increases Defense for all allies for 3 turns.
            /// </summary>
            Sup_Marakukaja,
            /// <summary>
            /// Increases Accuracy/Evasion for all allies for 3 turns.
            /// </summary>
            Sup_Masukukaja,
            /// <summary>
            /// Increases ATK/DEF/Accuracy/Evasion for all allies.
            /// </summary>
            Sup_All_Kaja,
            /// <summary>
            /// Next attack deals over double the damage for all allies.
            /// </summary>
            Sup_Charge,
            /// <summary>
            /// Restores 50% HP to all allies.
            /// </summary>
            Sup_HP_____,
            /// <summary>
            /// Restores 10% SP to all allies.
            /// </summary>
            Sup_SP_____,
            /// <summary>
            /// Escape 100% successfully from all battles except for bosses.
            /// </summary>
            Sup_Escape_Route,
            /// <summary>
            /// View how effective an attack will be when targeting a foe.
            /// </summary>
            Sup_Third_Eye,
            /// <summary>
            /// Restores 10% HP to backup members after battle.
            /// </summary>
            Subrecover_HP,
            /// <summary>
            /// Restores 1% SP to backup members after battle.
            /// </summary>
            Subrecover_SP,
            /// <summary>
            /// Confirm affinities of enemies you have previously attacked.
            /// </summary>
            Analysis_0442,
            /// <summary>
            /// Confirm affinities and skills of enemies you have previously attacked .
            /// </summary>
            Deep_Analysis,
            /// <summary>
            /// Confirm enemy skills and all affinities, including those not yet attacked.
            /// </summary>
            Full_Analysis,
            /// <summary>
            /// BLANK
            /// </summary>
            All_Out_Attack,
            /// <summary>
            /// Miniscule Wind dmg to all foes.
            /// </summary>
            Dust_Flurry,
            /// <summary>
            /// BLANK
            /// </summary>
            Tongue_Whip,
            /// <summary>
            /// BLANK
            /// </summary>
            Whip_Strike,
            /// <summary>
            /// BLANK
            /// </summary>
            Lustful_Slurp,
            /// <summary>
            /// BLANK
            /// </summary>
            Libido_Boost,
            /// <summary>
            /// BLANK
            /// </summary>
            Golden_Knife,
            /// <summary>
            /// BLANK
            /// </summary>
            Lick,
            /// <summary>
            /// BLANK
            /// </summary>
            Gold_Medal_Spike,
            /// <summary>
            /// Miniscule Phys dmg to one foe 2-5 times.
            /// </summary>
            Volleyball_Assault,
            /// <summary>
            /// BLANK
            /// </summary>
            Maelstrom,
            /// <summary>
            /// BLANK
            /// </summary>
            Flame_Dance,
            /// <summary>
            /// BLANK
            /// </summary>
            Silent_Snowscape,
            /// <summary>
            /// BLANK
            /// </summary>
            Thunderclap,
            /// <summary>
            /// BLANK
            /// </summary>
            Maeiga_0459,
            /// <summary>
            /// BLANK
            /// </summary>
            Hunger_All,
            /// <summary>
            /// BLANK
            /// </summary>
            Ocular_Vulcan,
            /// <summary>
            /// BLANK
            /// </summary>
            Missile_Party,
            /// <summary>
            /// BLANK
            /// </summary>
            Fear_Gas,
            /// <summary>
            /// BLANK
            /// </summary>
            Super_VIP_Form,
            /// <summary>
            /// BLANK
            /// </summary>
            March_of_the_Piggy,
            /// <summary>
            /// BLANK
            /// </summary>
            Sphinx_Swipe_0466,
            /// <summary>
            /// BLANK
            /// </summary>
            Wing_Blast,
            /// <summary>
            /// BLANK
            /// </summary>
            Rapid_Ascent,
            /// <summary>
            /// BLANK
            /// </summary>
            Sphinx_Dive,
            /// <summary>
            /// BLANK
            /// </summary>
            Dreadful_Scream,
            /// <summary>
            /// BLANK
            /// </summary>
            Bite,
            /// <summary>
            /// BLANK
            /// </summary>
            Restore,
            /// <summary>
            /// BLANK
            /// </summary>
            The_Artists_Grace,
            /// <summary>
            /// BLANK
            /// </summary>
            Work_Order,
            /// <summary>
            /// BLANK
            /// </summary>
            Sacrifice_Order,
            /// <summary>
            /// BLANK
            /// </summary>
            Selfless_Devotion,
            /// <summary>
            /// BLANK
            /// </summary>
            Penalty,
            /// <summary>
            /// BLANK
            /// </summary>
            Coin_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Severing_Slash,
            /// <summary>
            /// BLANK
            /// </summary>
            Gatling_Gun,
            /// <summary>
            /// BLANK
            /// </summary>
            Berserker_Dance,
            /// <summary>
            /// BLANK
            /// </summary>
            Roulette__HP,
            /// <summary>
            /// BLANK
            /// </summary>
            Roulette__SP,
            /// <summary>
            /// BLANK
            /// </summary>
            Roulette__Money,
            /// <summary>
            /// BLANK
            /// </summary>
            Roulette__Aid__,
            /// <summary>
            /// BLANK
            /// </summary>
            Roulette__Aid___0486,
            /// <summary>
            /// BLANK
            /// </summary>
            Roulette__Aid___0487,
            /// <summary>
            /// BLANK
            /// </summary>
            Beast_Kings_Wrath,
            /// <summary>
            /// BLANK
            /// </summary>
            Hunting_Stance,
            /// <summary>
            /// BLANK
            /// </summary>
            Arm_of_Destruction,
            /// <summary>
            /// BLANK
            /// </summary>
            Gryphons_Breath,
            /// <summary>
            /// BLANK
            /// </summary>
            Royal_Wing_Beam,
            /// <summary>
            /// BLANK
            /// </summary>
            Cannon_Fire,
            /// <summary>
            /// BLANK
            /// </summary>
            Cannon_Barrage,
            /// <summary>
            /// BLANK
            /// </summary>
            Unholy_Convergence,
            /// <summary>
            /// BLANK
            /// </summary>
            Pyramid_Blast,
            /// <summary>
            /// BLANK
            /// </summary>
            Tyrants_Fist,
            /// <summary>
            /// BLANK
            /// </summary>
            Tyrants_Glare,
            /// <summary>
            /// BLANK
            /// </summary>
            Tyrants_Wave,
            /// <summary>
            /// Item: Recovers 20 HP
            /// </summary>
            Fig_Seed,
            /// <summary>
            /// Item: Recovers 100 HP
            /// </summary>
            Medicine,
            /// <summary>
            /// Item: Recovers 200 HP
            /// </summary>
            Ointment,
            /// <summary>
            /// Item: Recovers 400 HP
            /// </summary>
            Antibiotic_Gel,
            /// <summary>
            /// Item: Recovers 30% HP
            /// </summary>
            Life_Stone,
            /// <summary>
            /// Item: Fully recovers HP
            /// </summary>
            Bead,
            /// <summary>
            /// Item: All recover 100 HP
            /// </summary>
            Value_Medicine,
            /// <summary>
            /// Item: All recover 200 HP
            /// </summary>
            Medical_Kit,
            /// <summary>
            /// Item: All recover 400 HP
            /// </summary>
            Maka_Leaf,
            /// <summary>
            /// Item: Fully recovers HP
            /// </summary>
            Bead_Chain,
            /// <summary>
            /// Item: Recovers 10 SP
            /// </summary>
            Soul_Drop,
            /// <summary>
            /// Item: Recovers 50 SP
            /// </summary>
            Snuff_Soul,
            /// <summary>
            /// Item: Recovers 100 SP
            /// </summary>
            Chewing_Soul,
            /// <summary>
            /// Item: Fully Recovers SP
            /// </summary>
            Soul_Food,
            /// <summary>
            /// Item: Revive
            /// </summary>
            Revival_Bead,
            /// <summary>
            /// Item: Revives with full HP
            /// </summary>
            Balm_of_Life,
            /// <summary>
            /// Item: Cures Mouse
            /// </summary>
            Royel_Jelly,
            /// <summary>
            /// Unused Item
            /// </summary>
            Organic_Herb,
            /// <summary>
            /// Item: Cures Forget/Dizzy/Sleep
            /// </summary>
            Disclose,
            /// <summary>
            /// Item: Cures Confuse/Fear/Rage/Despair/Brainwash
            /// </summary>
            Tranquilizer,
            /// <summary>
            /// Unused Item
            /// </summary>
            Kopi_Luwak,
            /// <summary>
            /// Item: Return to Metaverse entrance
            /// </summary>
            Goho_M,
            /// <summary>
            /// Item: Escape from battle
            /// </summary>
            Vanish_Ball,
            /// <summary>
            /// Item: Fully recovers HP and SP
            /// </summary>
            Soma,
            /// <summary>
            /// Item: Cures all ailments except Down and KO
            /// </summary>
            Amrita_Soda,
            /// <summary>
            /// Item: Cures all ailments except Down and KO
            /// </summary>
            Hiranya,
            /// <summary>
            /// Item: Recovers 30% HP for 1 ally, inflicts Rakunda and Tarukaja
            /// </summary>
            Muscle_Drink,
            /// <summary>
            /// Item: Recovers 30% HP for 1 ally, inflicts Sukunda and Tarukaja
            /// </summary>
            Odd_Morsel,
            /// <summary>
            /// Item: Recovers 30% HP for 1 ally, inflicts Taranda and Sukukaja
            /// </summary>
            Rancid_Gravy,
            /// <summary>
            /// Item: When Joker is KO'd, fully recovers all allies
            /// </summary>
            Plume_of_Dusk,
            /// <summary>
            /// Item: A barrier that reflects all but Phys/Almighty
            /// </summary>
            Magic_Mirror,
            /// <summary>
            /// Item: A barrier that reflects Phys skills
            /// </summary>
            Physical_Mirror,
            /// <summary>
            /// Item: Attack up for all allies
            /// </summary>
            Universe_Ring,
            /// <summary>
            /// Item: Evasion up for all allies
            /// </summary>
            Sleipnir,
            /// <summary>
            /// Item: Defense up for all allies
            /// </summary>
            Obsidian_Mirror,
            /// <summary>
            /// Item: Attack up for all allies
            /// </summary>
            Purifying_Water,
            /// <summary>
            /// Item: Negates stat debuffs for all allies
            /// </summary>
            Purifying_Salt,
            /// <summary>
            /// Item: 50 Fire damage
            /// </summary>
            Firecracker,
            /// <summary>
            /// Item: 50 Fire damage
            /// </summary>
            San_zun_Tama,
            /// <summary>
            /// Item: 50 Ice damage
            /// </summary>
            Ice_Cube,
            /// <summary>
            /// Item: 50 Ice damage
            /// </summary>
            Dry_Ice,
            /// <summary>
            /// Item: 50 Wind damage
            /// </summary>
            Pinwheel,
            /// <summary>
            /// Item: 50 Wind damage
            /// </summary>
            Yashichi,
            /// <summary>
            /// Item: 50 Elec damage
            /// </summary>
            Ball_Lightning,
            /// <summary>
            /// Item: 50 Elec damage
            /// </summary>
            Tesla_Coil,
            /// <summary>
            /// Item: 100 Almighty damage
            /// </summary>
            Smart_Bomb,
            /// <summary>
            /// Item: Bless insta-kill
            /// </summary>
            Segami_Rice,
            /// <summary>
            /// Item: Curse insta-kill
            /// </summary>
            Curse_Paper,
            /// <summary>
            /// Item: 150 Fire damage
            /// </summary>
            Flame_Magatama,
            /// <summary>
            /// Item: 150 Wind damage
            /// </summary>
            Wind_Magatama,
            /// <summary>
            /// Item: 150 Ice damage
            /// </summary>
            Freeze_Magatama,
            /// <summary>
            /// Item: 150 Elec damage
            /// </summary>
            Bolt_Magatama,
            /// <summary>
            /// Item: Blocks an insta-kill attack
            /// </summary>
            Homunculus,
            /// <summary>
            /// BLANK
            /// </summary>
            Removal_Potion,
            /// <summary>
            /// Item: 50 Bless damage
            /// </summary>
            Kouga_Ball,
            /// <summary>
            /// Item: 50 Bless damage
            /// </summary>
            Makouha_Ball,
            /// <summary>
            /// Item: 50 Curse damage
            /// </summary>
            Eiga_Ball,
            /// <summary>
            /// Item: 50 Curse damage
            /// </summary>
            Maeiga_Ball,
            /// <summary>
            /// Item: 50 Psy damage
            /// </summary>
            Psio_Ball,
            /// <summary>
            /// Item: 50 Psy damage
            /// </summary>
            Mapsi_Ball,
            /// <summary>
            /// Item: 50 Nuke damage
            /// </summary>
            Freila_Ball,
            /// <summary>
            /// Item: 50 Nuke damage
            /// </summary>
            Mafrei_Ball,
            /// <summary>
            /// Item: 150 Nuke damage
            /// </summary>
            Nuke_Magatama,
            /// <summary>
            /// Item: 150 Psy damage
            /// </summary>
            Psy_Magatama,
            /// <summary>
            /// Item: 150 Bless damage
            /// </summary>
            Bless_Magatama,
            /// <summary>
            /// Item: 150 Curse damage
            /// </summary>
            Curse_Magatama,
            /// <summary>
            /// Item: Cures Hunger. Moderate HP recovery.
            /// </summary>
            Cooking,
            /// <summary>
            /// Item: Cures Hunger. Slight HP recovery.
            /// </summary>
            Snack,
            /// <summary>
            /// Item: Recovers 10 HP for 1 ally
            /// </summary>
            Shoes__,
            /// <summary>
            /// Item: Recovers 30 HP for 1 ally
            /// </summary>
            Shoes___0569,
            /// <summary>
            /// Item: Recovers 5 SP for 1 ally
            /// </summary>
            Shoes___0570,
            /// <summary>
            /// Item: Recovers 50 HP for 1 ally. Cures ailments.
            /// </summary>
            Juice_Bar__,
            /// <summary>
            /// Item: Recovers 30 HP for 1 ally. Cures Rage/Despair/Brainwash/Confuse.
            /// </summary>
            Juice_Bar___0572,
            /// <summary>
            /// Item: Recovers 30 HP for 1 ally. Cures Burn/Freeze/Shock.
            /// </summary>
            Juice_Bar___0573,
            /// <summary>
            /// Item: Recovers 30 HP for 1 ally. Cures Dizzy/Forget/Sleep.
            /// </summary>
            Juice_Bar___0574,
            /// <summary>
            /// Item: Recovers 30 HP for 1 ally. Sukunda to self.
            /// </summary>
            Energy_Drink__,
            /// <summary>
            /// Item: Recovers 100 HP for 1 ally. Tarunda to self.
            /// </summary>
            Energy_Drink___0576,
            /// <summary>
            /// Item: Recovers 200 HP for 1 ally. Rakunda to self.
            /// </summary>
            Energy_Drink___0577,
            /// <summary>
            /// Item: Recovers 100 HP for 1 ally. Rakunda/Sukunda to self.
            /// </summary>
            Soda__,
            /// <summary>
            /// Item: Recovers 100 HP for 1 ally. Sukunda/Tarunda to self.
            /// </summary>
            Soda___0579,
            /// <summary>
            /// Item: Recovers 100 HP for 1 ally. Tarunda/Rakunda to self.
            /// </summary>
            Soda___0580,
            /// <summary>
            /// Item: Recovers 30% HP for 1 ally. Debilitate to self.
            /// </summary>
            Soda___0581,
            /// <summary>
            /// Item: Recovers 10% SP for 1 ally. Rakunda to self.
            /// </summary>
            Ration__,
            /// <summary>
            /// Item: Recover 10% SP for 1 ally. Sukunda to self.
            /// </summary>
            Ration___0583,
            /// <summary>
            /// Item: Recover 10% SP for 1 ally. Tarunda to self.
            /// </summary>
            Ration___0584,
            /// <summary>
            /// BLANK
            /// </summary>
            Drug_Store__,
            /// <summary>
            /// BLANK
            /// </summary>
            Drug_Store___0586,
            /// <summary>
            /// BLANK
            /// </summary>
            Drug_Store___0587,
            /// <summary>
            /// BLANK
            /// </summary>
            Drug_Store___0588,
            /// <summary>
            /// BLANK
            /// </summary>
            Drug_Store___0589,
            /// <summary>
            /// Item: Recovers 10 HP
            /// </summary>
            Drug_Store___0590,
            /// <summary>
            /// Item: Recovers 25 HP
            /// </summary>
            Drug_Store___0591,
            /// <summary>
            /// Item: Recovers 50 HP
            /// </summary>
            Drug_Store___0592,
            /// <summary>
            /// Item: Recovers 5 SP
            /// </summary>
            Drug_Store___0593,
            /// <summary>
            /// Item: Recovers 25 SP
            /// </summary>
            Drug_Store___,
            /// <summary>
            /// BLANK
            /// </summary>
            Drug_Store____0595,
            /// <summary>
            /// BLANK
            /// </summary>
            Drug_Store____0596,
            /// <summary>
            /// BLANK
            /// </summary>
            Special_Coffee__,
            /// <summary>
            /// BLANK
            /// </summary>
            Special_Coffee___0598,
            /// <summary>
            /// BLANK
            /// </summary>
            Double_Fangs_0599,
            /// <summary>
            /// BLANK
            /// </summary>
            Twins_Down_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Caro_Rod,
            /// <summary>
            /// BLANK
            /// </summary>
            Caro_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Megidolaon_0603,
            /// <summary>
            /// BLANK
            /// </summary>
            Rays_of_Control,
            /// <summary>
            /// BLANK
            /// </summary>
            Rays_of_Control_0605,
            /// <summary>
            /// BLANK
            /// </summary>
            Rays_of_Control_0606,
            /// <summary>
            /// BLANK
            /// </summary>
            Rays_of_Control_0607,
            /// <summary>
            /// BLANK
            /// </summary>
            Arrow_of_Light,
            /// <summary>
            /// BLANK
            /// </summary>
            Diffraction_Arrow,
            /// <summary>
            /// BLANK
            /// </summary>
            Light_Edge,
            /// <summary>
            /// BLANK
            /// </summary>
            Gathering_Light,
            /// <summary>
            /// BLANK
            /// </summary>
            Eternal_Light,
            /// <summary>
            /// BLANK
            /// </summary>
            Holy_Change,
            /// <summary>
            /// BLANK
            /// </summary>
            Distortion_Wave,
            /// <summary>
            /// BLANK
            /// </summary>
            Tough_Law,
            /// <summary>
            /// BLANK
            /// </summary>
            Frail_Law,
            /// <summary>
            /// BLANK
            /// </summary>
            New_Creation,
            /// <summary>
            /// BLANK
            /// </summary>
            Distortion_Surge,
            /// <summary>
            /// BLANK
            /// </summary>
            Arrow_of_Light_0619,
            /// <summary>
            /// BLANK
            /// </summary>
            Manifest_Sword,
            /// <summary>
            /// BLANK
            /// </summary>
            Manifest_Gun,
            /// <summary>
            /// BLANK
            /// </summary>
            Manifest_Bell,
            /// <summary>
            /// BLANK
            /// </summary>
            Sword_of_Judgment,
            /// <summary>
            /// BLANK
            /// </summary>
            Capital_Punishment,
            /// <summary>
            /// BLANK
            /// </summary>
            Manifest_Book,
            /// <summary>
            /// BLANK
            /// </summary>
            Distorted_Lust,
            /// <summary>
            /// BLANK
            /// </summary>
            Gospel,
            /// <summary>
            /// BLANK
            /// </summary>
            Distorted_Wrath,
            /// <summary>
            /// BLANK
            /// </summary>
            Distorted_Vanity,
            /// <summary>
            /// BLANK
            /// </summary>
            Song_of_Salvation,
            /// <summary>
            /// BLANK
            /// </summary>
            Wrath_of_God,
            /// <summary>
            /// BLANK
            /// </summary>
            Distorted_Gluttony,
            /// <summary>
            /// BLANK
            /// </summary>
            Distorted_Envy,
            /// <summary>
            /// BLANK
            /// </summary>
            Song_of_Placation,
            /// <summary>
            /// BLANK
            /// </summary>
            Divine_Apex,
            /// <summary>
            /// BLANK
            /// </summary>
            Rays_of_Control_0636,
            /// <summary>
            /// BLANK
            /// </summary>
            Distorted_Avarice,
            /// <summary>
            /// BLANK
            /// </summary>
            Will_of_the_People,
            /// <summary>
            /// BLANK
            /// </summary>
            Rays_of_Control_0639,
            /// <summary>
            /// Casts various buffs on allies.
            /// </summary>
            Moral_Support,
            /// <summary>
            /// Casts even more buffs on allies.
            /// </summary>
            Active_Support,
            /// <summary>
            /// Recognize the most effective choice in Demon Negotiations.
            /// </summary>
            Mental_Hack,
            /// <summary>
            /// Swaps fallen ally with a backup member.
            /// </summary>
            Emergency_Shift,
            /// <summary>
            /// Chance of nullifying attacks directed at entire party.
            /// </summary>
            Final_Guard,
            /// <summary>
            /// Low chance of Hold Up at the start of battle except when ambushed.
            /// </summary>
            Position_Hack,
            /// <summary>
            /// View attribute affinities and skills when Analyzing.
            /// </summary>
            High_Analyze,
            /// <summary>
            /// Find out if a foe is carrying a rare item ahead of time.
            /// </summary>
            Treasure_Skimmer,
            /// <summary>
            /// Restores 20% HP to backup members after battle.
            /// </summary>
            Subrecover_HP_EX,
            /// <summary>
            /// Restores 3% SP to backup members after battle.
            /// </summary>
            Subrecover_SP_EX,
            /// <summary>
            /// BLANK
            /// </summary>
            Big_Bang_Treat,
            /// <summary>
            /// BLANK
            /// </summary>
            Explosion_0651,
            /// <summary>
            /// BLANK
            /// </summary>
            Explosion_0652,
            /// <summary>
            /// BLANK
            /// </summary>
            Explosion_0653,
            /// <summary>
            /// BLANK
            /// </summary>
            Big_Bang_Order,
            /// <summary>
            /// BLANK
            /// </summary>
            Roulette_Time,
            /// <summary>
            /// Downs one foe.
            /// </summary>
            Trip_Upper,
            /// <summary>
            /// Medium Almighty dmg to all foes.
            /// </summary>
            Lust_Sphere,
            /// <summary>
            /// BLANK
            /// </summary>
            Down_Shot__,
            /// <summary>
            /// BLANK
            /// </summary>
            Down_Shot___0659,
            /// <summary>
            /// BLANK
            /// </summary>
            Down_Shot___0660,
            /// <summary>
            /// Heavy dmg to one foe, ignoring affinities.
            /// </summary>
            Electro_Attack,
            /// <summary>
            /// A bullet made from the Seven Deadly Sins. Can pierce even a god.
            /// </summary>
            Sinful_Shell,
            /// <summary>
            /// BLANK
            /// </summary>
            Follow_Black,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0664,
            /// <summary>
            /// BLANK
            /// </summary>
            Madara_Megido,
            /// <summary>
            /// BLANK
            /// </summary>
            Curry_Raku,
            /// <summary>
            /// BLANK
            /// </summary>
            Enemy_Benefit,
            /// <summary>
            /// BLANK
            /// </summary>
            Diarahan_0668,
            /// <summary>
            /// BLANK
            /// </summary>
            Curry_Suku,
            /// <summary>
            /// BLANK
            /// </summary>
            Decoy_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Super_Decoy_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Metabolic_Wave,
            /// <summary>
            /// Colossal Phys dmg to one foe.
            /// </summary>
            Laevateinn_0673,
            /// <summary>
            /// BLANK
            /// </summary>
            Desperation,
            /// <summary>
            /// BLANK
            /// </summary>
            Call_of_Chaos,
            /// <summary>
            /// BLANK
            /// </summary>
            Big_Bang_Challenge,
            /// <summary>
            /// BLANK
            /// </summary>
            Grail_Light__,
            /// <summary>
            /// BLANK
            /// </summary>
            Megidola_0678,
            /// <summary>
            /// BLANK
            /// </summary>
            Rage_Transmission,
            /// <summary>
            /// BLANK
            /// </summary>
            Hundred_Slaps,
            /// <summary>
            /// BLANK
            /// </summary>
            Distorted_Pride,
            /// <summary>
            /// BLANK
            /// </summary>
            Divine_Punishment,
            /// <summary>
            /// BLANK
            /// </summary>
            Will_of_the_People_0683,
            /// <summary>
            /// BLANK
            /// </summary>
            Wind_Cutter,
            /// <summary>
            /// BLANK
            /// </summary>
            Shoot_Up,
            /// <summary>
            /// BLANK
            /// </summary>
            Executive_Punch,
            /// <summary>
            /// BLANK
            /// </summary>
            Megidolaon_0687,
            /// <summary>
            /// BLANK
            /// </summary>
            Vorpal_Blade_0688,
            /// <summary>
            /// BLANK
            /// </summary>
            Megidolaon_0689,
            /// <summary>
            /// BLANK
            /// </summary>
            Big_Bang_Burger,
            /// <summary>
            /// BLANK
            /// </summary>
            Earth_Burger,
            /// <summary>
            /// BLANK
            /// </summary>
            Mars_Burger,
            /// <summary>
            /// BLANK
            /// </summary>
            Moon_Burger,
            /// <summary>
            /// BLANK
            /// </summary>
            Saturn_Burger,
            /// <summary>
            /// BLANK
            /// </summary>
            Justine_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Caroline_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Curry_Makara,
            /// <summary>
            /// BLANK
            /// </summary>
            Curry_Tetra,
            /// <summary>
            /// BLANK
            /// </summary>
            Curry_Endure,
            /// <summary>
            /// BLANK
            /// </summary>
            Curry_Charge,
            /// <summary>
            /// BLANK
            /// </summary>
            Curry_Concentrate,
            /// <summary>
            /// BLANK
            /// </summary>
            Curry_Heat_Riser,
            /// <summary>
            /// Nullifies all magical attacks except Almighty for one ally.
            /// </summary>
            BLANK_0703,
            /// <summary>
            /// Restores 50% HP and increases Accuracy/Evasion for all allies.
            /// </summary>
            Cadenza,
            /// <summary>
            /// Heavy Phys dmg to one foe 2 times. High Accuracy.
            /// </summary>
            Cross_Slash,
            /// <summary>
            /// Heavy Almighty dmg to all foes. Medium chance of insta-kill.
            /// </summary>
            Door_of_Hades,
            /// <summary>
            /// Heavy Curse dmg to all foes. Chance of Confuse/Fear/Despair.
            /// </summary>
            Magatsu_Mandala,
            /// <summary>
            /// Light Bless dmg to all foes 4-8 times.
            /// </summary>
            Shining_Arrows,
            /// <summary>
            /// Colossal Phys dmg to one foe. Decreases Attack.
            /// </summary>
            Beast_Weaver,
            /// <summary>
            /// Severe Fire dmg to all foes, with high chance of Fear.
            /// </summary>
            Titanomachia,
            /// <summary>
            /// Severe Curse dmg to all foes.
            /// </summary>
            Abyssal_Wings,
            /// <summary>
            /// Fully restores HP and removes all stat debuffs for all allies.
            /// </summary>
            Oratario,
            /// <summary>
            /// Heavy Almighty dmg to all foes 3 times.
            /// </summary>
            Myriad_Truths,
            /// <summary>
            /// Restores 50% HP and increases ATK/DEF/ACC/EV for allies.
            /// </summary>
            Neo_Cadenza,
            /// <summary>
            /// Severe Phys dmg to all foes with high chance of Critical 1-2 times.
            /// </summary>
            Akashic_Arts,
            /// <summary>
            /// High chance of inflicting Sleep to all foes.
            /// </summary>
            Phantom_Show,
            /// <summary>
            /// BLANK
            /// </summary>
            Confuse_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Baptism_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Exorcism_Ball,
            /// <summary>
            /// BLANK
            /// </summary>
            Megido_0720,
            /// <summary>
            /// BLANK
            /// </summary>
            Megidola_0721,
            /// <summary>
            /// BLANK
            /// </summary>
            Megidolaon_0722,
            /// <summary>
            /// BLANK
            /// </summary>
            Slam,
            /// <summary>
            /// BLANK
            /// </summary>
            Megaton_Raid_0724,
            /// <summary>
            /// BLANK
            /// </summary>
            One_shot_Kill_0725,
            /// <summary>
            /// BLANK
            /// </summary>
            Inferno_0726,
            /// <summary>
            /// BLANK
            /// </summary>
            Diamond_Dust_0727,
            /// <summary>
            /// BLANK
            /// </summary>
            Eternal_Radiance,
            /// <summary>
            /// BLANK
            /// </summary>
            Tyrant_Chaos,
            /// <summary>
            /// BLANK
            /// </summary>
            New_Curry__,
            /// <summary>
            /// BLANK
            /// </summary>
            New_Curry___0731,
            /// <summary>
            /// BLANK
            /// </summary>
            Reviv_All,
            /// <summary>
            /// BLANK
            /// </summary>
            Reviv_All_Z,
            /// <summary>
            /// BLANK
            /// </summary>
            Dark_Akechi_For_pursuing,
            /// <summary>
            /// BLANK
            /// </summary>
            Dark_Akechi_For_Gun_pursuing,
            /// <summary>
            /// BLANK
            /// </summary>
            Wild_Talk,
            /// <summary>
            /// BLANK
            /// </summary>
            Baton_Pass,
            /// <summary>
            /// BLANK
            /// </summary>
            Punk_Talk,
            /// <summary>
            /// BLANK
            /// </summary>
            Pickpocket,
            /// <summary>
            /// BLANK
            /// </summary>
            Harisen_Recovery,
            /// <summary>
            /// BLANK
            /// </summary>
            Protect,
            /// <summary>
            /// BLANK
            /// </summary>
            Girl_Talk,
            /// <summary>
            /// BLANK
            /// </summary>
            Crocodile_Tears,
            /// <summary>
            /// BLANK
            /// </summary>
            Sexy_Technique,
            /// <summary>
            /// BLANK
            /// </summary>
            Detective_Talk,
            /// <summary>
            /// BLANK
            /// </summary>
            Artist_Talk,
            /// <summary>
            /// BLANK
            /// </summary>
            Negotiating,
            /// <summary>
            /// BLANK
            /// </summary>
            Fundraising,
            /// <summary>
            /// BLANK
            /// </summary>
            Manipulation,
            /// <summary>
            /// BLANK
            /// </summary>
            Mind_Control,
            /// <summary>
            /// BLANK
            /// </summary>
            Charisma_Speech,
            /// <summary>
            /// BLANK
            /// </summary>
            Brainiac_Talk,
            /// <summary>
            /// BLANK
            /// </summary>
            Sabaki,
            /// <summary>
            /// BLANK
            /// </summary>
            Kakoi_Kuzushi,
            /// <summary>
            /// BLANK
            /// </summary>
            Touryou,
            /// <summary>
            /// BLANK
            /// </summary>
            Togo_System,
            /// <summary>
            /// BLANK
            /// </summary>
            Bullet_Hail,
            /// <summary>
            /// BLANK
            /// </summary>
            Warning_Shot,
            /// <summary>
            /// BLANK
            /// </summary>
            Celeb_Talk,
            /// <summary>
            /// BLANK
            /// </summary>
            Kitty_Talk,
            /// <summary>
            /// BLANK
            /// </summary>
            Marin_Karin_0761,
            /// <summary>
            /// BLANK
            /// </summary>
            Womanizing,
            /// <summary>
            /// BLANK
            /// </summary>
            Indignant_Revenge,
            /// <summary>
            /// BLANK
            /// </summary>
            Healing_Power,
            /// <summary>
            /// BLANK
            /// </summary>
            Healing_Power_0765,
            /// <summary>
            /// BLANK
            /// </summary>
            Taunt_0766,
            /// <summary>
            /// BLANK
            /// </summary>
            Iridescent_Change,
            /// <summary>
            /// BLANK
            /// </summary>
            Brave_Blade_0768,
            /// <summary>
            /// BLANK
            /// </summary>
            Assault_Dive_0769,
            /// <summary>
            /// BLANK
            /// </summary>
            Terror_Claw_0770,
            /// <summary>
            /// BLANK
            /// </summary>
            Bufudyne_0771,
            /// <summary>
            /// BLANK
            /// </summary>
            Psiodyne_0772,
            /// <summary>
            /// BLANK
            /// </summary>
            Mazionga_0773,
            /// <summary>
            /// BLANK
            /// </summary>
            Maziodyne_0774,
            /// <summary>
            /// BLANK
            /// </summary>
            Maeiga_0775,
            /// <summary>
            /// BLANK
            /// </summary>
            Maeigaon_0776,
            /// <summary>
            /// BLANK
            /// </summary>
            Adam_Skill___0777,
            /// <summary>
            /// BLANK
            /// </summary>
            Adam_SKill__,
            /// <summary>
            /// BLANK
            /// </summary>
            Vorpal_Blade_0779,
            /// <summary>
            /// BLANK
            /// </summary>
            Mona_Ryuji_Unison_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Mona_Ann_Unison_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Mona_Haru_Unison_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Yusuke_Ann_Unison_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Ryuji_Yusuke_Unison_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Ryuji_Makoto_Unison_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Protag_Akechi_Unison_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Makoto_Haru_Unison_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            UNUSED__Akechi_Unison_Attack,
            /// <summary>
            /// BLANK
            /// </summary>
            Protag_Kasumi_Unison_Attack,
            /// <summary>
            /// Severe Curse dmg to one foe.
            /// </summary>
            Mona_Ryuji_Unison_Attack_790,
            /// <summary>
            /// Severe Elec dmg to one foe.
            /// </summary>
            Mona_Ann_Unison_Attack_791,
            /// <summary>
            /// Severe Wind dmg to one foe. Effective vs Burn.
            /// </summary>
            Mona_Haru_Unison_Attack_792,
            /// <summary>
            /// Severe Fire dmg to one foe.
            /// </summary>
            Yusuke_Ann_Unison_Attack_793,
            /// <summary>
            /// Severe Ice dmg to one foe.
            /// </summary>
            Ryuji_Yusuke_Unison_Attack_794,
            /// <summary>
            /// Severe Nuke dmg to one foe.
            /// </summary>
            Ryuji_Makoto_Unison_Attack_795,
            /// <summary>
            /// Severe Psy dmg to one foe.
            /// </summary>
            Protag_Akechi_Unison_Attack_796,
            /// <summary>
            /// BLANK
            /// </summary>
            Makoto_Haru_Unison_Attack_797,
            /// <summary>
            /// Severe Bless dmg to one foe.
            /// </summary>
            UNUSED__Akechi_Unison_Attack_798,
            /// <summary>
            /// Severe Almighty dmg to one foe.
            /// </summary>
            Protag_Kasumi_Unison_Attack_799,
            /// <summary>
            /// 10% chance of reflecting physical attacks.
            /// </summary>
            Counter,
            /// <summary>
            /// 15% chance of reflecting physical attacks. Does not stack.
            /// </summary>
            Counterstrike,
            /// <summary>
            /// 20% chance of reflecting physical attacks. Does not stack.
            /// </summary>
            High_Counter,
            /// <summary>
            /// Decreases chances of being inflicted with Burn.
            /// </summary>
            Resist_Burn,
            /// <summary>
            /// Prevents infliction of Burn.
            /// </summary>
            Null_Burn,
            /// <summary>
            /// Revives with 1 HP when KO'd. Usable once per battle.
            /// </summary>
            Endure,
            /// <summary>
            /// Revives with full HP when KO'd. Usable once per battle.
            /// </summary>
            Enduring_Soul,
            /// <summary>
            /// Decreases chances of being inflicted with Freeze.
            /// </summary>
            Resist_Freeze,
            /// <summary>
            /// Prevents infliction of Freeze.
            /// </summary>
            Null_Freeze,
            /// <summary>
            /// Survive insta-kill skills with 1 HP.
            /// </summary>
            Survival_Trick,
            /// <summary>
            /// Increases Evasion from Fire skills.
            /// </summary>
            Dodge_Fire,
            /// <summary>
            /// Greatly increases Evasion from Fire skills. Does not stack.
            /// </summary>
            Evade_Fire,
            /// <summary>
            /// Increases Evasion from Ice skills.
            /// </summary>
            Dodge_Ice,
            /// <summary>
            /// Greatly increases Evasion from Ice skills. Does not stack.
            /// </summary>
            Evade_Ice,
            /// <summary>
            /// Increases Evasion from Wind skills.
            /// </summary>
            Dodge_Wind,
            /// <summary>
            /// Greatly increases Evasion from Wind skills. Does not stack.
            /// </summary>
            Evade_Wind,
            /// <summary>
            /// Increases Evasion from Elec skills.
            /// </summary>
            Dodge_Elec,
            /// <summary>
            /// Greatly increases Evasion from Elec skills. Does not stack.
            /// </summary>
            Evade_Elec,
            /// <summary>
            /// Increases Evasion from Phys skills.
            /// </summary>
            Dodge_Phys,
            /// <summary>
            /// Greatly increases Evasion from Phys skills. Does not stack.
            /// </summary>
            Evade_Phys,
            /// <summary>
            /// Strengthens Fire skills by 25%.
            /// </summary>
            Fire_Boost,
            /// <summary>
            /// Strengthens Fire skills by 50%. Can stack.
            /// </summary>
            Fire_Amp,
            /// <summary>
            /// Strengthens Ice skills by 25%.
            /// </summary>
            Ice_Boost,
            /// <summary>
            /// Strengthens Ice skills by 50%. Can stack.
            /// </summary>
            Ice_Amp,
            /// <summary>
            /// Strengthens Wind skills by 25%.
            /// </summary>
            Wind_Boost,
            /// <summary>
            /// Strengthens Wind skills by 50%. Can stack.
            /// </summary>
            Wind_Amp,
            /// <summary>
            /// Strengthens Elec skills by 25%.
            /// </summary>
            Elec_Boost,
            /// <summary>
            /// Strengthens Elec skills by 50%. Can stack.
            /// </summary>
            Elec_Amp,
            /// <summary>
            /// Increases Evasion from all magical attacks except Almighty.
            /// </summary>
            Angelic_Grace,
            /// <summary>
            /// Increases the effect of healing skills by 50%.
            /// </summary>
            Divine_Grace,
            /// <summary>
            /// Restores 2% of max HP each turn in battle.
            /// </summary>
            Regenerate__,
            /// <summary>
            /// Restores 4% of max HP each turn in battle.
            /// </summary>
            Regenerate___831,
            /// <summary>
            /// Restores 6% of max HP each turn in battle.
            /// </summary>
            Regenerate___832,
            /// <summary>
            /// Increases Evasion from non-Hama Bless skills.
            /// </summary>
            Dodge_Bless,
            /// <summary>
            /// Increases Evasion from non-Mudo Curse skills.
            /// </summary>
            Dodge_Curse,
            /// <summary>
            /// Restores 3 SP each turn in battle.
            /// </summary>
            Invigorate__,
            /// <summary>
            /// Restores 5 SP each turn in battle.
            /// </summary>
            Invigorate___836,
            /// <summary>
            /// Restores 7 SP each turn in battle.
            /// </summary>
            Invigorate___837,
            /// <summary>
            /// Greatly increases Evasion from non-Hama Bless skills. Does not stack.
            /// </summary>
            Evade_Bless,
            /// <summary>
            /// Greatly increases Evasion from non-Mudo Curse skills. Does not stack.
            /// </summary>
            Evade_Curse,
            /// <summary>
            /// Automatic Tarukaja at the start of battle.
            /// </summary>
            Attack_Master,
            /// <summary>
            /// Automatic Matarukaja at the start of battle.
            /// </summary>
            Auto_Mataru,
            /// <summary>
            /// Decreases chances of being inflicted with Shock.
            /// </summary>
            Resist_Shock,
            /// <summary>
            /// Automatic Rakukaja at the start of battle.
            /// </summary>
            Defense_Master,
            /// <summary>
            /// Automatic Marakukaja at the start of battle.
            /// </summary>
            Auto_Maraku,
            /// <summary>
            /// Prevents infliction of Shock.
            /// </summary>
            Null_Shock,
            /// <summary>
            /// Automatic Sukukaja at the start of battle.
            /// </summary>
            Speed_Master,
            /// <summary>
            /// Automatic Masukukaja at the start of battle.
            /// </summary>
            Auto_Masuku,
            /// <summary>
            /// Decreases chances of being inflicted with Hunger.
            /// </summary>
            Resist_Hunger,
            /// <summary>
            /// Prevents infliction of Hunger.
            /// </summary>
            Null_Hunger,
            /// <summary>
            /// Decreases recovery time from ailments by half.
            /// </summary>
            Fast_Heal,
            /// <summary>
            /// Decreases recovery time from ailments to 1 turn.
            /// </summary>
            Insta_Heal,
            /// <summary>
            /// Decreases HP cost of skills by half.
            /// </summary>
            Arms_Master,
            /// <summary>
            /// Decreases SP cost of skills by half.
            /// </summary>
            Spell_Master,
            /// <summary>
            /// Increases Attack when inflicted by Rage.
            /// </summary>
            Rage_Atk_Up,
            /// <summary>
            /// Decreases chance of being hit by a Critical.
            /// </summary>
            Sharp_Student,
            /// <summary>
            /// Increases chance of Critical.
            /// </summary>
            Apt_Pupil,
            /// <summary>
            /// Greatly decreases Accuracy for one foe.
            /// </summary>
            Ali_Dance,
            /// <summary>
            /// Take the blow, but decreases damage by half.
            /// </summary>
            Firm_Stance,
            /// <summary>
            /// EXP gained in battle increased by 1.5x.
            /// </summary>
            Plus_____EXP,
            /// <summary>
            /// Restores 8% of max HP/SP after battle.
            /// </summary>
            Life_Aid,
            /// <summary>
            /// Fully restores HP/SP after battle.
            /// </summary>
            Victory_Cry,
            /// <summary>
            /// Earn 25% EXP even when not participating in battle.
            /// </summary>
            Growth__,
            /// <summary>
            /// Earn 50% EXP even when not participating in battle.
            /// </summary>
            Growth___863,
            /// <summary>
            /// Earn 100% EXP even when not participating in battle.
            /// </summary>
            Growth___864,
            /// <summary>
            /// Prevents infliction of Confuse/Fear/Rage/Despair.
            /// </summary>
            Unshaken_Will,
            /// <summary>
            /// Nullifies Hama attacks.
            /// </summary>
            Null_Bless_Insta_kill,
            /// <summary>
            /// Calm things down with humor. Usable when Sense is at "Sensitive."
            /// </summary>
            Baton_Pass_867,
            /// <summary>
            /// Identify who has Treasure in Mementos. Usable when Instinct is at "Wild."
            /// </summary>
            Soul_Touch,
            /// <summary>
            /// BLANK
            /// </summary>
            Kakoi_Kuzushi_869,
            /// <summary>
            /// Increases resistance to Fire attacks. Nullifies weakness.
            /// </summary>
            Resist_Fire,
            /// <summary>
            /// Nullifies Fire attacks.
            /// </summary>
            Null_Fire,
            /// <summary>
            /// Reflects Fire attacks.
            /// </summary>
            Repel_Fire,
            /// <summary>
            /// Absorbs damage from Fire attacks.
            /// </summary>
            Drain_Fire,
            /// <summary>
            /// Nullifies Mudo attacks.
            /// </summary>
            Null_Curse_Insta_kill,
            /// <summary>
            /// Increases resistance to Ice attacks. Nullifies weakness.
            /// </summary>
            Resist_Ice,
            /// <summary>
            /// Nullifies Ice attacks.
            /// </summary>
            Null_Ice,
            /// <summary>
            /// Reflects Ice attacks.
            /// </summary>
            Repel_Ice,
            /// <summary>
            /// Absorbs damage from Ice attacks.
            /// </summary>
            Drain_Ice,
            /// <summary>
            /// EXP gained in battle increased by 15%.
            /// </summary>
            Plus_____EXP_879,
            /// <summary>
            /// Increases resistance to Wind attacks. Nullifies weakness.
            /// </summary>
            Resist_Wind,
            /// <summary>
            /// Nullifies Wind attacks.
            /// </summary>
            Null_Wind,
            /// <summary>
            /// Reflects Wind attacks.
            /// </summary>
            Repel_Wind,
            /// <summary>
            /// Absorbs damage from Wind attacks.
            /// </summary>
            Drain_Wind,
            /// <summary>
            /// Increases strength of All-Out Attacks.
            /// </summary>
            All_Out_Attack_Boost,
            /// <summary>
            /// Increases resistance to Elec attacks. Nullifies weakness.
            /// </summary>
            Resist_Elec,
            /// <summary>
            /// Nullifies Elec attacks.
            /// </summary>
            Null_Elec,
            /// <summary>
            /// Reflects Elec attacks.
            /// </summary>
            Repel_Elec,
            /// <summary>
            /// Absorbs damage from Elec attacks.
            /// </summary>
            Drain_Elec,
            /// <summary>
            /// Increases money gained by 15%.
            /// </summary>
            Money_Boost,
            /// <summary>
            /// Increases resistance to Bless attacks. Nullifies weakness.
            /// </summary>
            Resist_Bless,
            /// <summary>
            /// Nullifies Bless attacks.
            /// </summary>
            Null_Bless,
            /// <summary>
            /// Reflects Bless attacks.
            /// </summary>
            Repel_Bless,
            /// <summary>
            /// Absorbs damage from Bless attacks.
            /// </summary>
            Drain_Bless,
            /// <summary>
            /// Decreases chance of being targeted by foes.
            /// </summary>
            Hide,
            /// <summary>
            /// Increases resistance to Curse attacks. Nullifies weakness.
            /// </summary>
            Resist_Curse,
            /// <summary>
            /// Nullifies Curse attacks.
            /// </summary>
            Null_Curse,
            /// <summary>
            /// Reflects Curse attacks.
            /// </summary>
            Repel_Curse,
            /// <summary>
            /// Absorbs damage from Curse attacks.
            /// </summary>
            Drain_Curse,
            /// <summary>
            /// Increases max SP by 20.
            /// </summary>
            Life_Boost,
            /// <summary>
            /// Increases resistance to Phys attacks. Nullifies weakness.
            /// </summary>
            Resist_Phys,
            /// <summary>
            /// Nullifies Phys attacks.
            /// </summary>
            Null_Phys,
            /// <summary>
            /// Reflects Phys attacks.
            /// </summary>
            Repel_Phys,
            /// <summary>
            /// Absorbs damage from Phys attacks.
            /// </summary>
            Drain_Phys,
            /// <summary>
            /// Nullifies Bless/Curse skills.
            /// </summary>
            Null_Bless_Curse,
            /// <summary>
            /// Increases chance of inflicting ailments.
            /// </summary>
            Ailment_Boost,
            /// <summary>
            /// Increases success rate of Hama skills.
            /// </summary>
            Hama_Boost,
            /// <summary>
            /// Increases success rate of Mudo skills.
            /// </summary>
            Mudo_Boost,
            /// <summary>
            /// Increases Accuracy of Gun attacks by 5%.
            /// </summary>
            Gun_Accuracy_Plus___,
            /// <summary>
            /// Increases Evasion from Criticals and magical attacks.
            /// </summary>
            Samurai_Spirit,
            /// <summary>
            /// Increases chance of inflicting Dizzy.
            /// </summary>
            Dizzy_Boost,
            /// <summary>
            /// Increases chance of inflicting Confuse.
            /// </summary>
            Confuse_Boost,
            /// <summary>
            /// Increases chance of inflicting Fear.
            /// </summary>
            Fear_Boost,
            /// <summary>
            /// Increases chance of inflicting Forget.
            /// </summary>
            Forget_Boost,
            /// <summary>
            /// Increases chance of inflicting Sleep.
            /// </summary>
            Sleep_Boost,
            /// <summary>
            /// Increases chance of inflicting Rage.
            /// </summary>
            Rage_Boost,
            /// <summary>
            /// Increases chance of inflicting Despair.
            /// </summary>
            Despair_Boost,
            /// <summary>
            /// Decreases HP and SP cost of skills by 25%.
            /// </summary>
            Kuzunoha_Emblem,
            /// <summary>
            /// Increases chance of inflicting Brainwash.
            /// </summary>
            Brainwash_Boost,
            /// <summary>
            /// Greatly increases chance of Critical.
            /// </summary>
            Critical_Rate_Up_High,
            /// <summary>
            /// Decreases chances of being inflicted with Dizzy.
            /// </summary>
            Resist_Dizzy,
            /// <summary>
            /// Decreases chances of being inflicted with Confuse.
            /// </summary>
            Resist_Confuse,
            /// <summary>
            /// Decreases chances of being inflicted with Fear.
            /// </summary>
            Resist_Fear,
            /// <summary>
            /// Decreases chances of being inflicted with Forget.
            /// </summary>
            Resist_Forget,
            /// <summary>
            /// Decreases chances of being inflicted with Sleep.
            /// </summary>
            Resist_Sleep,
            /// <summary>
            /// Decreases chances of being inflicted with Rage.
            /// </summary>
            Resist_Rage,
            /// <summary>
            /// Decreases chances of being inflicted with Despair.
            /// </summary>
            Resist_Despair,
            /// <summary>
            /// Increases fusion accident rate.
            /// </summary>
            Fusion_Accident_Up,
            /// <summary>
            /// Decreases chances of being inflicted with Brainwash.
            /// </summary>
            Resist_Brainwash,
            /// <summary>
            /// Strengthens all attacks. Can stack.
            /// </summary>
            Tyrants_Mind,
            /// <summary>
            /// Prevents infliction of Dizzy.
            /// </summary>
            Null_Dizzy,
            /// <summary>
            /// Prevents infliction of Confuse.
            /// </summary>
            Null_Confuse,
            /// <summary>
            /// Prevents infliction of Fear.
            /// </summary>
            Null_Fear,
            /// <summary>
            /// Prevents infliction of Forget.
            /// </summary>
            Null_Forget,
            /// <summary>
            /// Prevents infliction of Sleep.
            /// </summary>
            Null_Sleep,
            /// <summary>
            /// Prevents infliction of Rage.
            /// </summary>
            Null_Rage,
            /// <summary>
            /// Prevents infliction of Despair.
            /// </summary>
            Null_Despair,
            /// <summary>
            /// Restores 15% HP and 15 SP each turn in battle.
            /// </summary>
            Holy_Whisper,
            /// <summary>
            /// Prevents infliction of Brainwash.
            /// </summary>
            Null_Brainwash,
            /// <summary>
            /// Restores 25% HP each turn in battle.
            /// </summary>
            Holy_Embrace,
            /// <summary>
            /// Increases chance of inflicting Burn.
            /// </summary>
            Burn_Boost,
            /// <summary>
            /// Increases chance of inflicting Freeze.
            /// </summary>
            Freeze_Boost,
            /// <summary>
            /// Increases chance of inflicting Shock.
            /// </summary>
            Shock_Boost,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_943,
            /// <summary>
            /// Increases Critical rate during an Ambush.
            /// </summary>
            Fortified_Moxy,
            /// <summary>
            /// Increases Critical rate when surrounded.
            /// </summary>
            Adverse_Resolve,
            /// <summary>
            /// Greatly decreases Accuracy of all foes' attacks except Almighty when surrounded.
            /// </summary>
            Last_Stand,
            /// <summary>
            /// Restores 5% max HP and 10 SP each turn during an Ambush.
            /// </summary>
            Heat_Up,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_948,
            /// <summary>
            /// Automatic Sukukaja after a Baton Pass.
            /// </summary>
            Touch_n_Go,
            /// <summary>
            /// Greatly increases Evasion from all affinities during Rain/Snow.
            /// </summary>
            Climate_Decorum,
            /// <summary>
            /// Increases chance of inflicting ailments during Rain/Snow.
            /// </summary>
            Ambient_Aid,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE,
            /// <summary>
            /// Strengthens Gun skills by 25%.
            /// </summary>
            Snipe,
            /// <summary>
            /// Strengthens Gun skills by 50%. Can stack.
            /// </summary>
            Cripple,
            /// <summary>
            /// Increases chance of Critical from Gun attacks.
            /// </summary>
            Trigger_Happy,
            /// <summary>
            /// Increases resistance to Nuke attacks. Nullifies weakness.
            /// </summary>
            Resist_Nuke,
            /// <summary>
            /// Nullifies Nuke attacks.
            /// </summary>
            Null_Nuke,
            /// <summary>
            /// Reflects Nuke attacks.
            /// </summary>
            Repel_Nuke,
            /// <summary>
            /// Absorbs damage from Nuke attacks.
            /// </summary>
            Drain_Nuke,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_960,
            /// <summary>
            /// Increases resistance to Psy attacks. Nullifies weakness.
            /// </summary>
            Resist_Psy,
            /// <summary>
            /// Nullifies Psy attacks.
            /// </summary>
            Null_Psy,
            /// <summary>
            /// Reflects Psy attacks.
            /// </summary>
            Repel_Psy,
            /// <summary>
            /// Absorbs damage from Psy attacks.
            /// </summary>
            Drain_Psy,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_965,
            /// <summary>
            /// Strengthens Nuke skills by 25%.
            /// </summary>
            Nuke_Boost,
            /// <summary>
            /// Strengthens Nuke skills by 50%. Can stack.
            /// </summary>
            Nuke_Amp,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_968,
            /// <summary>
            /// Strengthens Psy skills by 25%.
            /// </summary>
            Psy_Boost,
            /// <summary>
            /// Strengthens Psy skills by 50%. Can stack.
            /// </summary>
            Psy_Amp,
            /// <summary>
            /// BLANK
            /// </summary>
            Sexy_Technique_971,
            /// <summary>
            /// Increases Evasion from Nuke skills.
            /// </summary>
            Dodge_Nuke,
            /// <summary>
            /// Greatly increases Evasion from Nuke skills. Does not stack.
            /// </summary>
            Evade_Nuke,
            /// <summary>
            /// BLANK
            /// </summary>
            Detox,
            /// <summary>
            /// Increases Evasion from Psy skills.
            /// </summary>
            Dodge_Psy,
            /// <summary>
            /// Greatly increases Evasion from Psy skills. Does not stack.
            /// </summary>
            Evade_Psy,
            /// <summary>
            /// BLANK
            /// </summary>
            Detox_977,
            /// <summary>
            /// Strengthens Bless skills by 25%.
            /// </summary>
            Bless_Boost,
            /// <summary>
            /// Strengthens Bless skills by 50%. Can stack.
            /// </summary>
            Bless_Amp,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_980,
            /// <summary>
            /// Strengthens Curse skills by 25%.
            /// </summary>
            Curse_Boost,
            /// <summary>
            /// Strengthens Curse skills by 50%. Can stack.
            /// </summary>
            Curse_Amp,
            /// <summary>
            /// Prevents discovery by foes roaming the Metaverse.
            /// </summary>
            Not_Found_By_Enemy,
            /// <summary>
            /// Strengthens all magic skills by 25%.
            /// </summary>
            Magic_Ability,
            /// <summary>
            /// Decreases chances of being inflicted with ailments.
            /// </summary>
            Fortify_Spirit,
            /// <summary>
            /// Strengthens Almighty skills by 25%.
            /// </summary>
            Almighty_Boost,
            /// <summary>
            /// Strengthens Almighty skills by 50%. Can stack.
            /// </summary>
            Almighty_Amp,
            /// <summary>
            /// Nullifies all magical attacks except Almighty.
            /// </summary>
            Zenith_Defense,
            /// <summary>
            /// Restores 20 SP after a Baton Pass.
            /// </summary>
            Soul_Chain,
            /// <summary>
            /// Enable Skill Card copying.
            /// </summary>
            Vanity_Copy,
            /// <summary>
            /// Defeats weak foes during an Ambush and provides a Persona.
            /// </summary>
            Gluttonous_Snuff,
            /// <summary>
            /// Restores low amount of HP when using Guard.
            /// </summary>
            Sloth_Defense,
            /// <summary>
            /// Nullifies weaknesses.
            /// </summary>
            Brush_Of_Vanity,
            /// <summary>
            /// Increases max HP by 40%.
            /// </summary>
            Life_Rise,
            /// <summary>
            /// Increases max SP by 40%.
            /// </summary>
            Mana_Rise,
            /// <summary>
            /// Restores 5 SP after a Baton Pass.
            /// </summary>
            Soul_Touch_996,
            /// <summary>
            /// Victory Cry
            /// </summary>
            Victory_Cry_997,
            /// <summary>
            /// RESERVE
            /// </summary>
            Trait_DLC_for_Bitedown,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_999,
            /// <summary>
            /// Slightly increases dmg to enemies with ailments.
            /// </summary>
            Ailment_Effect_Up,
            /// <summary>
            /// Increases dmg to enemies with ailments.
            /// </summary>
            Ailment_Effect_Up__,
            /// <summary>
            /// Restores 3 SP after defeating a foe with Hama/Mudo attacks.
            /// </summary>
            Instakil_SP_Heal_Low,
            /// <summary>
            /// Restores 5 SP after defeating a foe with Hama/Mudo attacks.
            /// </summary>
            Instakil_SP_Heal_Mid,
            /// <summary>
            /// Restores 7 SP after defeating a foe with Hama/Mudo attacks.
            /// </summary>
            Instakil_SP_Heal_High,
            /// <summary>
            /// Slightly increases Technical damage.
            /// </summary>
            Technical_Effect_Up,
            /// <summary>
            /// Increases Technical damage.
            /// </summary>
            Technical_Effect_Up__,
            /// <summary>
            /// Slightly increases damage when low on HP.
            /// </summary>
            Low_HP_Attack_Up,
            /// <summary>
            /// Increases damage when low on HP.
            /// </summary>
            Low_HP_Attack_Up__,
            /// <summary>
            /// Slightly increases damage from attacks that target foe's weaknesses.
            /// </summary>
            WEAK_Hit_Effect_Up,
            /// <summary>
            /// Increases damage from attacks that target foe's weaknesses.
            /// </summary>
            WEAK_Hit_Effect_Up__,
            /// <summary>
            /// BLANK
            /// </summary>
            Null_Insta_kill,
            /// <summary>
            /// Decreases HP cost of skills by 10%.
            /// </summary>
            HP_Cost_Down____,
            /// <summary>
            /// Decreases HP cost of skills by 25%.
            /// </summary>
            HP_Cost_Down_____1013,
            /// <summary>
            /// Decreases SP cost of skills by 10%.
            /// </summary>
            SP_Cost_Down____,
            /// <summary>
            /// Decreases SP cost of skills by 25%.
            /// </summary>
            SP_Cost_Down_____1015,
            /// <summary>
            /// Increases the effect of healing skills by 10%.
            /// </summary>
            Heal_Magic_Up____,
            /// <summary>
            /// Increases the effect of healing skills by 25%.
            /// </summary>
            Heal_Magic_Up_____1017,
            /// <summary>
            /// Decreases HP cost of skills to 0.
            /// </summary>
            Chance_of___HP_cost,
            /// <summary>
            /// Decreases SP cost of skills to 0.
            /// </summary>
            Chance_of___SP_cost,
            /// <summary>
            /// Slightly increases damage of single target skills.
            /// </summary>
            Target_ATK_up,
            /// <summary>
            /// Increases damage of single target skills.
            /// </summary>
            Target_ATK_up__,
            /// <summary>
            /// All attacks are Critical, but Evasion becomes impossible.
            /// </summary>
            All_Crits__No_evasion,
            /// <summary>
            /// Reduce the SP cost of healing skills by 25%.
            /// </summary>
            Heal_Cost_Down____,
            /// <summary>
            /// Reduce the SP cost of healing skills by 10%.
            /// </summary>
            Heal_Cost_Down_____1024,
            /// <summary>
            /// Decreases Accuracy by half, but Attack doubles.
            /// </summary>
            ATK_Up__Aim_Down,
            /// <summary>
            /// Slightly increases chance of inflicting ailments.
            /// </summary>
            Ailment_Success_Up,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_1027,
            /// <summary>
            /// Strengthens magical attacks if possessing 4 or more affinity skills.
            /// </summary>
            __Affinity_Boost,
            /// <summary>
            /// Slightly strengthens magical attacks if possessing 3 or more affinity skills.
            /// </summary>
            __Affinity_Light_Boost,
            /// <summary>
            /// Increases effect period of support skills.
            /// </summary>
            Support_Turn_Extend,
            /// <summary>
            /// Slightly increases success rate of Hama/Mudo skills.
            /// </summary>
            Insta_kill_Up,
            /// <summary>
            /// Increases success rate of Hama/Mudo skills.
            /// </summary>
            Insta_kill_Up__,
            /// <summary>
            /// Increases max HP by 10%.
            /// </summary>
            Life_Bonus,
            /// <summary>
            /// Increases max HP by 20%.
            /// </summary>
            Life_Gain,
            /// <summary>
            /// Increases max HP by 30%.
            /// </summary>
            Life_Surge,
            /// <summary>
            /// Increases max SP by 10%.
            /// </summary>
            Mana_Bonus,
            /// <summary>
            /// Increases max SP by 20%.
            /// </summary>
            Mana_Gain,
            /// <summary>
            /// Increases max SP by 30%.
            /// </summary>
            Mana_Surge,
            /// <summary>
            /// Slightly increases Critical damage.
            /// </summary>
            Critical_Effect_Up,
            /// <summary>
            /// Increases Critical damage.
            /// </summary>
            Critical_Effect_Up__,
            /// <summary>
            /// Deals double the damage.
            /// </summary>
            Hit_Damage_Doubled,
            /// <summary>
            /// Slightly increases damage with all enemy target skills.
            /// </summary>
            All_Target_ATK_up,
            /// <summary>
            /// Increases damage with all enemy target skills.
            /// </summary>
            All_Target_ATK_up__,
            /// <summary>
            /// BLANK
            /// </summary>
            Auto_Barrier,
            /// <summary>
            /// Provide backup support during battle.
            /// </summary>
            Backup_Support,
            /// <summary>
            /// 100% chance of escape when running away on the 3rd turn of battle.
            /// </summary>
            Absolute_Escape,
            /// <summary>
            /// BLANK
            /// </summary>
            Shield_of_Loyalty,
            /// <summary>
            /// Strengthens all affinity skills by 50%.
            /// </summary>
            All_Amp,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_1049,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_1050,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_1051,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_1052,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_1053,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_1054,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_1055,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_1056,

        }

        /// <summary>
        /// A trait of a <see cref="Persona"/> or <see cref="Enemy"/>
        /// </summary>
        public enum Trait
        {
            /// <summary>
            /// BLANK
            /// </summary>
            No_Trait,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0002,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0003,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0004,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0005,
            /// <summary>
            /// Increased damage by 50% when hitting an enemy weakness
            /// </summary>
            Relentless,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0007,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE,
            /// <summary>
            /// Decreases SP cost of healing skills by half
            /// </summary>
            Saviour_Bloodline,
            /// <summary>
            /// Decreases SP cost of healing skills by 75%
            /// </summary>
            Grace_of_Mother,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0011,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0012,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0013,
            /// <summary>
            /// Decreases SP cost of support skills by half
            /// </summary>
            Relief_Bloodline,
            /// <summary>
            /// Decreases SP cost of support skills by 75%
            /// </summary>
            Ave_Maria,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0016,
            /// <summary>
            /// Increases chance of inflicting ailments
            /// </summary>
            Foul_Stench,
            /// <summary>
            /// Increases chance of inflicting ailments?
            /// </summary>
            RESERVE_0018,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0019,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0020,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0021,
            /// <summary>
            /// Increases chance of inflicting Shock on Downed foes
            /// </summary>
            Static_Electricity,
            /// <summary>
            /// Increases chance of inflicting ailments to Downed foes
            /// </summary>
            Ghost_Nest,
            /// <summary>
            /// Increase freeze chance after Baton Pass
            /// </summary>
            Cold_Blooded,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0025,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0026,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0027,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0028,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0029,
            /// <summary>
            /// Decreases SP cost of magic skills by 75%
            /// </summary>
            Allure_of_Wisdom,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0031,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0032,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0033,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0034,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0035,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0036,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0037,
            /// <summary>
            /// Increases damage to foes when low on HP
            /// </summary>
            Frenzied_Bull,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0039,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0040,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0041,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0042,
            /// <summary>
            /// BLANK
            /// </summary>
            BLANK_0043,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0044,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0045,
            /// <summary>
            /// Strengthens magic skills targeting one foe by 20%
            /// </summary>
            Intense_Focus,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0047,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0048,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0049,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0050,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0051,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0052,
            /// <summary>
            /// Increases damage of physical and curse attacks?
            /// </summary>
            RESERVE_0053,
            /// <summary>
            /// Strengthens magic skills targeting all foes by 20%
            /// </summary>
            Mighty_Gaze,
            /// <summary>
            /// BLANK
            /// </summary>
            Static_Electricity_0055,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0056,
            /// <summary>
            /// Strengthens Physical attacks by 20%.
            /// </summary>
            Striking_Weight,
            /// <summary>
            /// Strengthens Physical attacks by 30%.
            /// </summary>
            Undying_Fury,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0059,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0060,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0061,
            /// <summary>
            /// Doubles Counter damage.
            /// </summary>
            Retaliating_Body,
            /// <summary>
            /// Triples Counter damage.
            /// </summary>
            Inviolable_Beauty,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0064,
            /// <summary>
            /// Strengthen magic attacks by 50%.
            /// </summary>
            Pagan_Allure,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0066,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0067,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0068,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0069,
            /// <summary>
            /// Reduce susceptibility to all ailments.
            /// </summary>
            Rare_Antibody,
            /// <summary>
            /// Impart immunity against all ailments.
            /// </summary>
            Immunity,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0072,
            /// <summary>
            /// Increase Attack after Baton Pass. (Single target only)
            /// </summary>
            Skillful_Combo,
            /// <summary>
            /// Greatly increase Attack after Baton Pass. (Single target only)
            /// </summary>
            Linked_Bloodline,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0075,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0076,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0077,
            /// <summary>
            /// Increase chance of inflicting Ailments after Baton Pass.
            /// </summary>
            Foul_Odor,
            /// <summary>
            /// Increase chance of inflicting Burn after Baton Pass.
            /// </summary>
            Thermal_Conduct,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0080,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0081,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0082,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0083,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0084,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0085,
            /// <summary>
            /// Allows use of Ambush-only skills after Baton Pass.
            /// </summary>
            Pinch_Anchor,
            /// <summary>
            /// Allows use of ambush-only skills under normal conditions.
            /// </summary>
            Vitality_of_the_Tree,
            /// <summary>
            /// Activates all equipped special weather passives in normal weather.
            /// </summary>
            Gloomy_Child,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0089,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0090,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0091,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0092,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0093,
            /// <summary>
            /// BLANK
            /// </summary>
            Sinful_Technique,
            /// <summary>
            /// Strengthen Technical damage by 50%.
            /// </summary>
            Universal_Law,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0096,
            /// <summary>
            /// Increases Attack by 25% per ailment inflicted on foe.
            /// </summary>
            Ailment_Hunter,
            /// <summary>
            /// Increase Attack by 40% per ailment inflicted on foe.
            /// </summary>
            Hollow_Jester,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0099,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0100,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0101,
            /// <summary>
            /// Increase success rate of Instant Death skills.
            /// </summary>
            Deathly_Illness,
            /// <summary>
            /// Greatly increase success rate of Instant Death skills.
            /// </summary>
            Omen,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0104,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0105,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0106,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0107,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0108,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0109,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0110,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0111,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0112,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0113,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0114,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0115,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0116,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0117,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0118,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0119,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0120,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0121,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0122,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0123,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0124,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0125,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0126,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0127,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0128,
            /// <summary>
            /// All-Out Attacks may defeat all foes and restore 25% HP to all allies.
            /// </summary>
            Explosive_Scheme,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0130,
            /// <summary>
            /// All-Out Attacks may defeat all foes and fully restore HP to all allies.
            /// </summary>
            Infinite_Scheme,
            /// <summary>
            /// May increase allies' physical attacks by 40%.
            /// </summary>
            Raging_Temper,
            /// <summary>
            /// May increase power of allies' physical attacks by 80%.
            /// </summary>
            Eccentric_Temper,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0134,
            /// <summary>
            /// Increases effect of allies' healing skills.
            /// </summary>
            Proud_Presence,
            /// <summary>
            /// Increases effect of allies' healing skills. May decrease SP cost.
            /// </summary>
            Majestic_Presence,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0137,
            /// <summary>
            /// May decrease SP cost of allies' magic skills.
            /// </summary>
            Mastery_of_Magic,
            /// <summary>
            /// May decrease SP cost of allies' magic skills by half.
            /// </summary>
            Pinnacle_of_Magic,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0140,
            /// <summary>
            /// May slightly increase allies' chance to avoid physical attacks.
            /// </summary>
            Scoundrel_Eyes,
            /// <summary>
            /// May increase allies' chance to avoid physical attacks.
            /// </summary>
            Unparalleled_Eyes,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0143,
            /// <summary>
            /// Increase allies' chance of inflicting Burn/Freeze/Shock by 25%.
            /// </summary>
            Gaia_Pact,
            /// <summary>
            /// Increases allies' chance of inflicting Burn/Freeze/Shock by 50%.
            /// </summary>
            Gaia_Blessing,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0146,
            /// <summary>
            /// Decreases allies' chance of being inflicted by ailments by 25%.
            /// </summary>
            Icy_Glare,
            /// <summary>
            /// Decreases allies' chance of being inflicted by ailments by 50%.
            /// </summary>
            Cool_Customer,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0149,
            /// <summary>
            /// May decrease SP cost of allies' support skills by half.
            /// </summary>
            Tactical_Spirit,
            /// <summary>
            /// May decrease SP cost of allies' support/Almighty skills by half.
            /// </summary>
            Ingenious_Spirit,
            /// <summary>
            /// BLANK
            /// </summary>
            Flawless_Spirit,
            /// <summary>
            /// Increases chance of ally not being Downed when attacked.
            /// </summary>
            Veil_of_Midnight,
            /// <summary>
            /// Greatly increases chance of ally not being Downed when attacked.
            /// </summary>
            Veil_of_Sunrise,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0155,
            /// <summary>
            /// Reduce cost of Fire skills by 50%.
            /// </summary>
            Heated_Bloodline,
            /// <summary>
            /// Reduce cost of Fire skills by 75%
            /// </summary>
            Drunken_Passion,
            /// <summary>
            /// Reduce cost of Ice skills by 50%.
            /// </summary>
            Frigid_Bloodline,
            /// <summary>
            /// Reduce cost of Ice skills by 75%.
            /// </summary>
            Cocytus,
            /// <summary>
            /// Reduce cost of Elec skills by 50%.
            /// </summary>
            Electric_Bloodline,
            /// <summary>
            /// Reduce cost of Elec skills by 75%.
            /// </summary>
            Bargain_Bolts,
            /// <summary>
            /// Reduce cost of Wind skills by 50%.
            /// </summary>
            Wind_Bloodline,
            /// <summary>
            /// Reduce cost of Wind skills by 75%
            /// </summary>
            Vahanas_Wings,
            /// <summary>
            /// Reduce cost of Psy skills by 50%.
            /// </summary>
            Psychic_Bloodline,
            /// <summary>
            /// Reduce cost of Psy skills by 75%.
            /// </summary>
            Chi_Yous_Blessing,
            /// <summary>
            /// Reduce cost of Nuke skills by 50%.
            /// </summary>
            Atomic_Bloodline,
            /// <summary>
            /// Reduce cost of Nuke skills by 75%.
            /// </summary>
            Atomic_Hellscape,
            /// <summary>
            /// Reduce cost of Bless skills by 50%.
            /// </summary>
            Bless_Bloodline,
            /// <summary>
            /// Reduce cost of Bless skills by 75%
            /// </summary>
            Martyrs_Gift,
            /// <summary>
            /// Reduce cost of Curse skills by 50%.
            /// </summary>
            Cursed_Bloodline,
            /// <summary>
            /// Reduce cost of Curse skills by 75%
            /// </summary>
            Mothers_Lament,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0172,
            /// <summary>
            /// Increase amount of HP restored to self by 50%.
            /// </summary>
            Gluttonmouth,
            /// <summary>
            /// Doubles amount of HP restored to self.
            /// </summary>
            Demons_Bite,
            /// <summary>
            /// Increase amount of SP restored to self by 50%.
            /// </summary>
            Mouth_of_Savoring,
            /// <summary>
            /// Doubles amount of SP restored to self.
            /// </summary>
            Naranari,
            /// <summary>
            /// Doubles amount of HP/SP restored to self.
            /// </summary>
            Hallowed_Spirit,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0178,
            /// <summary>
            /// Increase buff timers by 2 turns for party.
            /// </summary>
            Wealth_of_Lotus,
            /// <summary>
            /// Buffs for self last 4 turns. Extends Auto- buffs for the entire party.
            /// </summary>
            Internal_Hypnosis,
            /// <summary>
            /// Buffs for self last 5 turns. Extends Auto- buffs for the entire party.
            /// </summary>
            Positive_Thoughts,
            /// <summary>
            /// Doubles effect of Drain-type skills and passives.
            /// </summary>
            Draining_Mouth,
            /// <summary>
            /// Expendable items not used up after Baton Pass.
            /// </summary>
            Tag_Team,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0184,
            /// <summary>
            /// Decreases SP cost by half after Baton Pass.
            /// </summary>
            Iron_Heart,
            /// <summary>
            /// Decrease damage received when struck by weakness.
            /// </summary>
            Crisis_Control,
            /// <summary>
            /// Increase allies' evasion against foes inflicted with ailments.
            /// </summary>
            Bloodstained_Eyes,
            /// <summary>
            /// Triples Charge/Concentrate damage
            /// </summary>
            Will_of_the_Sword,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0189,
            /// <summary>
            /// Revives with 1 HP when KO'd. Usable 4 times in battle.
            /// </summary>
            Circle_of_Sadness,
            /// <summary>
            /// Increases Attack by 50% during 1 More.
            /// </summary>
            Bolstering_Force,
            /// <summary>
            /// Increases chance of triggering ally's Persona traits.
            /// </summary>
            God_Maker,
            /// <summary>
            /// Increases chance of triggering ally's Follow Up attack.
            /// </summary>
            Hazy_Presence,
            /// <summary>
            /// Increases Attack/Defense based on Inmate Registry completion.
            /// </summary>
            Country_Maker,
            /// <summary>
            /// Decreases HP/SP cost to 0 during 1 More.
            /// </summary>
            Grace_of_the_Olive,
            /// <summary>
            /// Reduce cost of instant death skills to 0.
            /// </summary>
            Just_Die,
            /// <summary>
            /// BLANK
            /// </summary>
            Bless_Spirit,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0198,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0199,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0200,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0201,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0202,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0203,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0204,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0205,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0206,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0207,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0208,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0209,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0210,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0211,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0212,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0213,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0214,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0215,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0216,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0217,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0218,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0219,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0220,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0221,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0222,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0223,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0224,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0225,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0226,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0227,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0228,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0229,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0230,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0231,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0232,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0233,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0234,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0235,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0236,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0237,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0238,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0239,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0240,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0241,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0242,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0243,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0244,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0245,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0246,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0247,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0248,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0249,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0250,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0251,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0252,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0253,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0254,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0255,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0256,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0257,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0258,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0259,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0260,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0261,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0262,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0263,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0264,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0265,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0266,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0267,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0268,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0269,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0270,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0271,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0272,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0273,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0274,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0275,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0276,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0277,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0278,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0279,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0280,
            /// <summary>
            /// Generates bonus traits during fusion. (Regent)
            /// </summary>
            Ultimate_Vessel,
            /// <summary>
            /// Generates bonus traits during fusion. (Queen's Necklace)
            /// </summary>
            Ultimate_Vessel_0282,
            /// <summary>
            /// Generates bonus traits during fusion. (Stone of Scone)
            /// </summary>
            Ultimate_Vessel_0283,
            /// <summary>
            /// Generates bonus traits during fusion. (Koh-i-Noor)
            /// </summary>
            Ultimate_Vessel_0284,
            /// <summary>
            /// Generates bonus traits during fusion. (Orlov)
            /// </summary>
            Ultimate_Vessel_0285,
            /// <summary>
            /// Generates bonus traits during fusion. (Emperor's Amulet)
            /// </summary>
            Ultimate_Vessel_0286,
            /// <summary>
            /// Generates bonus traits during fusion. (Hope Diamond)
            /// </summary>
            Ultimate_Vessel_0287,
            /// <summary>
            /// Generates bonus traits during fusion. (Crystal Skull)
            /// </summary>
            Ultimate_Vessel_0288,
            /// <summary>
            /// Generates bonus traits during fusion. (Orichalcum)
            /// </summary>
            Ultimate_Vessel_0289,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0290,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0291,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0292,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0293,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0294,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0295,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0296,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0297,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0298,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0299,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0300,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0301,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0302,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0303,
            /// <summary>
            /// BLANK
            /// </summary>
            RESERVE_0304,

        }

        /// <summary>
        /// An enemy in the game
        /// </summary>
        public enum Enemy
        {
            Not_Used,
            Not_Used,
            Shadow_of_God,
            Fly_of_the_Dead,
            Spear_Wielding_General,
            Crypt_dwelling_Pyromaniac,
            Mocking_Snowman,
            Beguiling_Girl,
            Guard_Dog_of_Hades,
            Woman_Who_Brings_Ruin,
            War_Hungry_Horseman,
            Hero_Gathering_Tyrant,
            Girl_of_the_Hanging_Tree,
            Vicious_Pentagram,
            Throbbing_King_of_Desire,
            Cruel_Leopard,
            Thunder_Emperor,
            Expressionless_Beast,
            Herald_of_Death,
            Strumming_Veena_Player,
            Funerary_Warrior,
            Human_eating_Lady,
            Auspicious_Pachyderm,
            Bearer_of_the_Scales,
            Coffin_borne_God,
            Cleanser_of_Heaven,
            The_Shadowed_One,
            Prankster_Leader,
            Dancing_Lion,
            Rebellious_Elephant,
            Monarch_of_Snow,
            Self_Infatuated_Star,
            She_of_Life_and_Death,
            Slithering_Snakewoman,
            Fused_Ghost,
            Battle_Fiend,
            Night_Walking_Warrior,
            Rhetorician_of_the_Sea,
            Vicious_Young_Warrior,
            Scandalous_Queen,
            Bedside_Brute,
            Chivalrous_Fiend,
            Harlot_of_Desire,
            Dancing_Witch,
            Hunting_Wolf_Spirit,
            Destructive_Beauty,
            Declarer_of_Anguish,
            Angry_Warrior,
            Mysterious_Little_Girl,
            The_Blackened_Fury,
            Monk_of_the_Valley,
            Unfaithful_Dream_King,
            Bringer_of_Misfortune,
            Drunken_Serpents,
            Equine_Sage,
            Nimble_Monkey_King,
            Heavenly_Punisher,
            Piggyback_Demon,
            Midnight_Queen,
            Prison_Master,
            Abyssal_King_of_Avarice,
            Rooftop_Lion,
            Envoy_of_Slumber,
            Missionary_of_Depravity,
            Jealous_Lover,
            Bloody_Goddess,
            The_Black_Avenger,
            RESERVE,
            Embittered_Blacksmith,
            Twin_headed_Guardian,
            Twilight_Prostitute,
            Vampire_Moth,
            RESERVE_0071,
            Merciless_Inquisitor,
            Ascended_Feline,
            Evil_Snowman,
            Awakened_God,
            Zealous_Messenger,
            Quaking_Lady_of_Shadow,
            Mountain_Girl,
            RESERVE_0079,
            Divine_Warrior,
            Possessing_Dog_Ghost,
            Wandering_Reviver,
            RESERVE_0083,
            Viscid_Rotting_Meat,
            Thief_of_Tablets,
            RESERVE_0086,
            Grudging_Warrior_Arisen,
            Defeated_Avenger,
            Captivating_Dancer,
            Lamenting_Sacrifice,
            Life_Draining_Spirit,
            Shadowy_Ninja,
            Samurai_Killer,
            Raging_Water_Demon,
            Tornado_Devil,
            Arrogant_Vulture,
            Wishless_Star,
            Mad_Marsh_Horse,
            Chanting_Baboon,
            Hedonistic_Braggart,
            Waterside_Nymph,
            Menacing_Owlman,
            Torn_King_of_Desire,
            Leafy_Old_Man,
            Foolish_Monk,
            Regent,
            Queens_Necklace,
            Stone_of_Scone,
            Koh_i_Noor,
            Orlov,
            Emperors_Amulet,
            Hope_Diamond,
            Crystal_Skull,
            Orichalcum,
            RESERVE_0115,
            RESERVE_0116,
            RESERVE_0117,
            RESERVE_0118,
            RESERVE_0119,
            RESERVE_0120,
            Gallows_Flower,
            Reviled_Dictator,
            Bloodthirsty_Demoness,
            Troublesome_Housemaid,
            Killer_Teddy_Bear,
            Pulsing_Mud,
            Dirty_Two_horned_Beast,
            Dark_Sun,
            Noisy_Mountain_Spirit,
            Wavering_Tree_Spirit,
            Apprentice_in_a_Jug,
            Corpse_Bird,
            Night_Chimera,
            Corpse_eating_Corpse,
            Pagan_Savior,
            Heretic_Goat,
            Snake_King,
            Cavern_Snakeman,
            Raging_Bird_God,
            Sacrificial_Pyrekeeper,
            Final_Assessor,
            Ambassador_of_Filth,
            Brutal_Cavalryman,
            Gathering_Devil,
            RESERVE_0145,
            RESERVE_0146,
            RESERVE_0147,
            RESERVE_0148,
            RESERVE_0149,
            RESERVE_0150,
            RESERVE_0151,
            RESERVE_0152,
            RESERVE_0153,
            RESERVE_0154,
            RESERVE_0155,
            RESERVE_0156,
            Apocalyptic_Guide,
            RESERVE_0158,
            RESERVE_0159,
            RESERVE_0160,
            RESERVE_0161,
            RESERVE_0162,
            RESERVE_0163,
            RESERVE_0164,
            RESERVE_0165,
            RESERVE_0166,
            RESERVE_0167,
            RESERVE_0168,
            RESERVE_0169,
            Execurobo_MDL_ED,
            Corporobo_MDL_,
            Corporobo_MDL__0172,
            Corporobo_MDL__0173,
            Corporobo_MDL_CH,
            Corporobo_MDL_WKR,
            Samurai_Killer_0176,
            Raging_Water_Demon_0177,
            Tornado_Devil_0178,
            Raging_Bird_God_0179,
            Viscid_Rotting_Meat_0180,
            Troublesome_Housemaid_0181,
            Dancing_Witch_0182,
            Shadow_Takanashi,
            Shadow_Nakanohara,
            Defeated_Avenger_0185,
            Raging_Bird_God_0186,
            Torn_King_of_Desire_0187,
            RESERVE_0188,
            RESERVE_0189,
            The_Reaper,
            RESERVE_0191,
            RESERVE_0192,
            RESERVE_0193,
            Incubus,
            Justine,
            Caroline,
            Holy_Grail_Tentacle_A,
            Holy_Grail_Tentacle_B,
            Holy_Grail_Tentacle_C,
            RESERVE_0200,
            Suguru_Asmodeus_Kamoshida,
            Trophy_of_Obsession,
            Teacher_Boss_Post_Aff_Change,
            Weak_Tomb_of_Human_Sacrifice,
            Holy_Grail,
            Painters_Right_Eye,
            Painters_Left_Eye,
            Painters_Nose,
            Painters_Mouth,
            Ichiryusai_Azazel_Madarame,
            Museum_Boss_All_Weakness,
            Treasure_of_Mementos,
            Junya_Bael_Kaneshiro,
            Piggytron,
            Beast_That_Rules_the_Palace,
            Piggytron_0216,
            Goro_Akechi,
            Cognitive_Wakaba_Isshiki,
            Guard_Dog_of_Hades_0219,
            Spear_Wielding_General_0220,
            Kunikazu_Mammon_Okumura,
            Execurobo_MDL_ED_0222,
            Corporobo_MDL_GM,
            Corporobo_MDL_DM,
            Corporobo_MDL_AM,
            Corporobo_MDL_CH_0226,
            Corporobo_MDL_WKR_0227,
            Shadow_Sae,
            Sae_Leviathan_Niijima,
            Holy_Grail_0230,
            Goro_Akechi_0231,
            Goro_Akechi_0232,
            Beast_of_Human_Sacrifice,
            Wings_of_Human_Sacrifice,
            Tomb_of_Human_Sacrifice,
            Masayoshi_Samael_Shido,
            True_Masayoshi_Samael_Shido,
            Holy_Grail_0238,
            God_of_Control_Yaldabaoth,
            Sword_of_Conviction,
            Gun_of_Execution,
            Bell_of_Declaration,
            Book_of_Commandments,
            Justine_0244,
            Caroline_0245,
            Harus_Fianc姻,
            Museum_Boss__Right_Eye,
            Museum_Boss__Left_Eye,
            Museum_Boss__Nose,
            Museum_Boss__Mouth,
            Shadow_TV_President,
            Shadow_Cleaner,
            Crypt_dwelling_Pyromaniac_0253,
            Final_Assessor_0254,
            Snake_King_0255,
            Guard_Captain,
            Guard_Captain_0257,
            Sacrificial_Pyrekeeper_0258,
            Gallows_Flower_0259,
            Cruel_Leopard_0260,
            Dirty_Two_horned_Beast_0261,
            Shadow_Mr__Takase,
            Viscid_Rotting_Meat_0263,
            Shadow_Mrs__Magario,
            Beguiling_Girl_0265,
            Shadow_Oyamada,
            Rhetorician_of_the_Sea_0267,
            Shadow_Mr__Magario,
            Shadow_Nejima,
            Funerary_Warrior_0270,
            The_Black_Avenger_0271,
            Auspicious_Pachyderm_0272,
            Shadow_Uchimura,
            Heretic_Goat_0274,
            Shadow_Akitsu,
            RESERVE_0276,
            Security_Shadow,
            Shadow_Wakasa,
            Life_Draining_Spirit_0279,
            Guard_Dog_of_Hades_0280,
            Wandering_Reviver_0281,
            Shadow_Politician,
            Shadow_Shimizu,
            Shadow_IT_President,
            Embittered_Blacksmith_0285,
            Shadow_Honjo,
            Hunting_Wolf_Spirit_0287,
            Shadow_Jochi,
            Zealous_Messenger_0289,
            Sacrificial_Pyrekeeper_0290,
            Coffin_borne_God_0291,
            Shadow_Fukurai,
            Shadow_Takanashi_0293,
            Tornado_Devil_0294,
            Shadow_Oda,
            RESERVE_0296,
            Shadow_Sakoda,
            Shadow_Mrs__Takase,
            Shadow_Mogami,
            Shadow_Togo,
            Chivalrous_Fiend_0301,
            Cavern_Snakeman_0302,
            Heretic_Goat_0303,
            Shadow_Tsuda,
            Shadow_Isazuka,
            Midnight_Queen_0306,
            Shadow_Hashisato,
            Shadow_Isshiki,
            Shadow_Asakura,
            Shadow_Arita,
            Shadow_Shimomi,
            Shadow_Kishi,
            RESERVE_0313,
            Shadow_Takena,
            Shadow_Naguri,
            Shadow_Akitsu_0316,
            Shadow_Oda_0317,
            Shadow_Yoshioka,
            Wandering_Reviver_0319,
            Shadow_Odo,
            Shadow_Asakura_0321,
            Bearer_of_the_Scales_0322,
            Shadow_Mrs__Togo,
            Shadow_Tsuboi,
            Shadow_Former_Noble,
            Thief_of_Tablets_0326,
            Shadow_Kiritani,
            Thunder_Emperor_0328,
            Missionary_of_Depravity_0329,
            Heavenly_Punisher_0330,
            Dark_Sun_0331,
            RESERVE_0332,
            She_of_Life_and_Death_0333,
            RESERVE_0334,
            Scandalous_Queen_0335,
            Spear_Wielding_General_0336,
            Pagan_Savior_0337,
            Bringer_of_Misfortune_0338,
            Raging_Bird_God_0339,
            Thunder_Emperor_0340,
            Spear_Wielding_General_0341,
            Harlot_of_Desire_0342,
            Bedside_Brute_0343,
            Monk_of_the_Valley_0344,
            Battle_Fiend_0345,
            Awakened_God_0346,
            Shadow_Makigami,
            Chivalrous_Fiend_0348,
            Corpse_Bird_0349,
            RESERVE_0350,
            RESERVE_0351,
            RESERVE_0352,
            RESERVE_0353,
            RESERVE_0354,
            RESERVE_0355,
            RESERVE_0356,
            RESERVE_0357,
            RESERVE_0358,
            RESERVE_0359,
            RESERVE_0360,
            RESERVE_0361,
            RESERVE_0362,
            RESERVE_0363,
            RESERVE_0364,
            RESERVE_0365,
            RESERVE_0366,
            RESERVE_0367,
            RESERVE_0368,
            RESERVE_0369,
            RESERVE_0370,
            RESERVE_0371,
            RESERVE_0372,
            RESERVE_0373,
            RESERVE_0374,
            RESERVE_0375,
            RESERVE_0376,
            RESERVE_0377,
            RESERVE_0378,
            RESERVE_0379,
            RESERVE_0380,
            RESERVE_0381,
            RESERVE_0382,
            RESERVE_0383,
            RESERVE_0384,
            RESERVE_0385,
            RESERVE_0386,
            RESERVE_0387,
            RESERVE_0388,
            RESERVE_0389,
            RESERVE_0390,
            RESERVE_0391,
            RESERVE_0392,
            RESERVE_0393,
            RESERVE_0394,
            RESERVE_0395,
            RESERVE_0396,
            RESERVE_0397,
            RESERVE_0398,
            RESERVE_0399,
            RESERVE_0400,
            RESERVE_0401,
            RESERVE_0402,
            RESERVE_0403,
            RESERVE_0404,
            RESERVE_0405,
            RESERVE_0406,
            RESERVE_0407,
            RESERVE_0408,
            RESERVE_0409,
            RESERVE_0410,
            RESERVE_0411,
            RESERVE_0412,
            RESERVE_0413,
            RESERVE_0414,
            RESERVE_0415,
            RESERVE_0416,
            RESERVE_0417,
            RESERVE_0418,
            RESERVE_0419,
            RESERVE_0420,
            RESERVE_0421,
            RESERVE_0422,
            RESERVE_0423,
            Dancer_of_Death,
            Decadent_False_God,
            Storm_Invoking_Ptarmigan,
            Evil_Voracious_Dragon,
            Evil_Synthetic_Organism,
            Warped_Abyss,
            Trembling_Fairy_Knight,
            Fire_Assassin,
            Burning_Giant,
            Dream_Dwelling_Skull,
            Deformed_Lion_God,
            Infuriated_Wisdom_King,
            Hunting_Puss_in_Boots,
            Dragon_slaying_Genius,
            Guard_Dog_of_Hades_0438,
            Decadent_False_God_0439,
            ラヴェ専用ケルピー,
            ラヴェ専用ベリス,
            ラヴェ専用イヌガミ,
            ラヴェ専用ヌエ,
            ラヴェ専用オニ,
            ラヴェ専用アヌビス,
            ラヴェ専用ミトラス,
            ラヴェ専用オセ,
            ラヴェ専用アタバク,
            ラヴェ専用トール,
            ラヴェ専用ルシファー,
            P__Orpheus,
            P__Izanagi,
            P__Thanatos,
            P__Messiah,
            P__Attis,
            P__Siegfried,
            P__Kohryu,
            P__Kaguya,
            P__Sraosha,
            P__Yoshitsune,
            P__Izanagi_no_Okami,
            Pagan_Savior_0462,
            RESERVE_0463,
            Lavenza,
            Suguru_Asmodeus_Kamoshida_0465,
            Trophy_of_Obsession_0466,
            Teacher_Boss_Post_Aff_Change_0467,
            Painters_Right_Eye_0468,
            Painters_Left_Eye_0469,
            Painters_Nose_0470,
            Painters_Mouth_0471,
            Ichiryusai_Azazel_Madarame_0472,
            Museum_Boss_All_Weakness_0473,
            Junya_Bael_Kaneshiro_0474,
            Piggytron_0475,
            Cognitive_Wakaba_Isshiki_0476,
            Beast_That_Rules_the_Palace_0477,
            Execurobo_MDL_ED_0478,
            Corporobo_MDL_GM_0479,
            Corporobo_MDL_DM_0480,
            Corporobo_MDL_AM_0481,
            Corporobo_MDL_CH_0482,
            Corporobo_MDL_WKR_0483,
            Kunikazu_Mammon_Okumura_0484,
            Shadow_Sae_0485,
            Sae_Leviathan_Niijima_0486,
            Masayoshi_Samael_Shido_0487,
            True_Masayoshi_Samael_Shido_0488,
            Maruki,
            Cendrillon,
            Kasumi,
            Ersatz_Sorrow,
            Ersatz_Fury,
            Ersatz_Mirth,
            Ersatz_Joy,
            Sumire,
            Azathoth,
            Adam_Kadmon,
            Maruki_0499,
            Maruki_0500,
            Additional_Employee,
            Maruki_0502,
            Maruki_0503,
            Azathoth_0504,
            Azathoth__,
            EX_Kamoshida_Color_Change,
            Cognitive_Yuuki_Mishima,
            Cognitive_Shiho_Suzui,
            RESERVE_0509,
            Evil_Synthetic_Organism_0510,
            Pisaca,
            Evil_Synthetic_Organism_0512,
            Bedside_Brute_0513,
            Troublesome_Housemaid_0514,
            Dirty_Two_horned_Beast_0515,
            Dirty_Two_horned_Beast_0516,
            Dirty_Two_horned_Beast_0517,
            War_Hungry_Horseman_0518,
            Heavenly_Punisher_0519,
            Evil_Synthetic_Organism_0520,
            Warped_Abyss_0521,
            Hitman_For_Hire,
            Bodyguard_For_Hire,
            EXカネシロ攻略用踏み台,
            Evil_Synthetic_Organism_0525,
            Chivalrous_Fiend_0526,
            Decadent_False_God_0527,
            Awakened_God_0528,
            Monk_of_the_Valley_0529,
            Foolish_Monk_0530,
            Twin_headed_Guardian_0531,
            Battle_Fiend_0532,
            Funerary_Warrior_0533,
            Trembling_Fairy_Knight_0534,
            Prankster_Leader_0535,
            Prankster_Leader_0536,
            Gallows_Flower_0537,
            Killer_Teddy_Bear_0538,
            Shadow_Nagata,
            Cognitive_Kyoto_Nagata,
            Dancer_of_Death_0541,
            Reviled_Dictator_0542,
            Spear_Wielding_General_0543,
            The_Shadowed_One_0544,
            Evil_Snowman_0545,
            Fly_of_the_Dead_0546,
            Adam_Target__,
            Adam_Target___0548,
            Quaking_Lady_of_Shadow_0549,
            Dirty_Two_Horned_Beast,
            Tentacle_of_Assistance,
            Tentacle_of_Protection,
            Tentacle_of_Healing,
            Decadent_False_God_0554,
            Monarch_of_Snow_0555,
            Mocking_Snowman_0556,
            Mocking_Snowman_0557,
            Sae_Leviathan_Niijima_0558,
            Sae_Leviathan_Niijima_0559,
            Sae_Leviathan_Niijima_0560,
            Sae_Leviathan_Niijima_0561,
            Sae_Leviathan_Niijima_0562,
            Possessing_Dog_Ghost_0563,
            Adam_Kadmon_0564,
            Adam_Kadmon_0565,
            Adam_Kadmon_0566,
            Adam_Kadmon_0567,
            RESERVE_0568,
            Adam_Kadmon_0569,
            RESERVE_0570,
            RESERVE_0571,
            RESERVE_0572,
            RESERVE_0573,
            Hedonistic_Braggart_0574,
            The_Black_Avenger_0575,
            Harlot_of_Desire_0576,
            Liliths_Eldest_Daughter,
            Liliths_Second_Daughter,
            Liliths_Third_Daughter,
            Liliths_Fourth_Daughter,
            Corporobo_MDL__0581,
            Corporobo_MDL_WKR_0582,
            Merciless_Inquisitor_0583,
            Fire_Assassin_0584,
            The_Blackened_Fury_0585,
            Bloodthirsty_Demoness_0586,
            Azatoth_Tendril_Second_Half__,
            Azatoth_Tendril_Second_Half___0588,
            Azatoth_Tendril_Second_Half___0589,
            Azatoth_Tendril_Second_Half___0590,
            Azatoth_Tendril_Second_Half___0591,
            Azatoth_Tendril_Second_Half___0592,
            Missionary_of_Depravity_0593,
            Dream_Dwelling_Skull_0594,
            Goro_Akechi_0595,
            Blazing_Giant,
            Maruki_Second_Half,
            Adam_Kadmon_Second_Half,
            Brutal_Cavalryman_0599,
            Oni,
            Samurai_Killer_0601,
            Defeated_Avenger_0602,
            Bringer_of_Misfortune_0603,
            Possessing_Dog_Ghost_0604,
            Samurai_Killer_0605,
            Raging_Water_Demon_0606,
            Tornado_Devil_0607,
            Life_Draining_Spirit_0608,
            Cognitive_Haru_Okumura,
            Cognitive_Haru_Okumura_0610,
            Jose,
            Cruel_Leopard_0612,
            Arrogant_Vulture_0613,
            Cruel_Leopard_0614,
            Arrogant_Vulture_0615,
            Arrogant_Vulture_0616,
            Girl_Enthralled_by_a_Dream,
            Hallucinating_Captain,
            Daydreaming_Queen,
            Laughing_Snow_King,
            Pleasant_Snowman,
            Snowman_Living_an_Evil_Life,
            Joyful_Snake_King,
            Snakeman_in_an_Ominous_Place,
            Militant_Elephant,
            Wealth_Cultivating_Pachyderm,
            Insolent_Cavalryman,
            Night_Guard_Horseman,
            Delusive_Leopard,
            Omniscient_Fish_of_the_Sea,
            Shadowless_Pentagram,
            Light_Guardian,
            Guard_Dog_of_Paradise,
            Immortal_Feline,
            Playful_Puss_in_Boots,
            Endless_Pulsing_Mud,
            Bloated_Rotting_Meal,
            Satiated_Bird_God,
            Ecstatic_Vulture,
            Light_Indulgent_Messenger,
            Shining_Punisher,
            Sacred_Warrior,
            Entranced_Dancer,
            Raptured_Mountain_Girl,
            Jade_Comb_Wielder,
            Blood_Thirsty_Ogress,
            Debaucherous_Demoness,
            The_Blackened_Bloom,
            Inviting_Pyromaniac,
            Pleasant_Snowman_0650,
            Sae_Leviathan_Niijima_0651,
            Sae_Leviathan_Niijima_0652,
            Sae_Leviathan_Niijima_0653,
            Sae_Leviathan_Niijima_0654,
            Bearer_of_the_Scales_0655,
            Slithering_Snakewoman_0656,
            Rebellious_Elephant_0657,
            Vicious_Pentagram_0658,
            Quaking_Lady_of_Shadow_0659,
            Dancing_Witch_0660,
            Evil_Voracious_Dragon_0661,
            Dancer_of_Death_0662,
            Missionary_of_Depravity_0663,
            会話クエ_相性変更用,
            会話クエ_相性変更用_0665,
            会話クエ_相性変更用_0666,
            会話クエ_相性変更用_0667,
            会話クエ_相性変更用_0668,
            会話クエ_相性変更用_0669,
            会話クエ_相性変更用_0670,
            会話クエ_相性変更用_0671,
            会話クエ__相性変更用,
            Cait_Sith,
            Archangel,
            Succubus,
            Kelpie,
            High_Pixie,
            Berith,
            Yaksini,
            Eligor,
            Ippon_Datara,
            Shiki_Ouji,
            Nekomata,
            Shiisaa,
            Rakshasa,
            S_E_E_S__Boy,
            Investigation_Team_Boy,
            Hedonistic_Braggart_0688,
            Deformed_Lion_God_0689,
            Shadow_Kaneshiro,
            RESERVE_0691,
            RESERVE_0692,
            RESERVE_0693,
            RESERVE_0694,
            RESERVE_0695,
            RESERVE_0696,
            RESERVE_0697,
            RESERVE_0698,
            RESERVE_0699,
            Shadow_Aino,
            Shadow_Yatagai,
            Shadow_Arihara,
            Shadow_Ono,
            Shadow_Ono_0704,
            Shadow_Amasaki,
            Fused_Ghost_0706,
            Shadow_Saeki,
            Shadow_Amai,
            Shadow_Kagami,
            Shadow_Oi,
            Shadow_Chiyo,
            Shadow_Ushiwata,
            Shadow_Saburi,
            Shadow_Fuwa,
            Shadow_Minamoto,
            Shadow_Kagami_0716,
            会話クエ__パラ変更,
            Shadow_Nagata_0718,
            Cognitive_Kyoto_Nagata_0719,
            RESERVE_0720,
            RESERVE_0721,
            RESERVE_0722,
            RESERVE_0723,
            RESERVE_0724,
            Reviled_Dictator_0725,
            Bearer_of_the_Scales_0726,
            The_Blackened_Fury_0727,
            Final_Assessor_0728,
            Coffin_borne_God_0729,
            Pixie,
            Shadow_of_God_0731,
            Fly_of_the_Dead_0732,
            Hero_Gathering_Tyrant_0733,
            Thunder_Emperor_0734,
            Funerary_Warrior_0735,
            Arahabaki,
            Evil_Snowman_0737,
            Mocking_Snowman_0738,
            Herald_of_Death_0739,
            Jack_Frost,
            Cleanser_of_Heaven_0741,
            Koppa_Tengu,
            Jack_o_Lantern,
            S_E_E_S__Boy_0744,
            Investigation_Team_Boy_0745,
            Bicorn,
            Decarabia,
            Kaiwan,
            Fused_Ghost_0749,
            High_Pixie_0750,
            Mini_Mara,
            Pulsing_Mud_0752,
            Dakini,
            Pisaca_0754,
            Thoth,
            Scathach,
            Cu_Chulainn,
            Setanta,
            Koropokguru,
            Ongyo_Ki,
            Raja_Naga,
            Rakshasa_0762,
            Missionary_of_Depravity_0763,
            Wandering_Reviver_0764,
            Mysterious_Little_Girl_0765,
            Prison_Master_0766,
            Bloody_Goddess_0767,
            Thunder_Emperor_0768,
            Angry_Warrior_0769,
            Grudging_Warrior_Arisen_0770,
            Angry_Wisdom_King,
            Skadi,
            Loa,
            Dionysus,
            Mini_Mara_0775,
            Yamata_no_Orochi,
            Destructive_Beauty_0777,
            Beguiling_Girl_0778,
            Awakened_God_0779,
            Spear_Wielding_General_0780,
            Titania,
            RESERVE_0782,
        }

        /// <summary>
        /// An item in the game
        /// </summary>
        public enum Item
        {
            /// <summary>
            /// Useable by None
            /// </summary>
            BLANK = 0,
            /// <summary>
            /// Useable by All (Dagger icon)
            /// </summary>
            Unused = 1,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Rebel_Knife = 2,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Kukri = 3,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Arsenes_Cane = 4,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Blizz_Dagger = 5,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Athame = 6,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE = 7,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Skinning_Knife = 8,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_9 = 9,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Stun_Dagger = 10,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Killing_Scalpel = 11,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_12 = 12,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Helper_Knife = 13,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Pro_Skinning_Knife = 14,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_15 = 15,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Mega_Knife = 16,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Royal_Dagger = 17,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_18 = 18,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Machete = 19,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Baselard = 20,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_21 = 21,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Frenzy_Dagger = 22,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Pro_Parrying_Dagger = 23,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_24 = 24,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Misericorde = 25,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Parrying_Dagger = 26,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_27 = 27,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_28 = 28,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Kopis = 29,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Igniter = 30,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_31 = 31,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_32 = 32,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_33 = 33,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_34 = 34,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Paradise_Lost = 35,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_36 = 36,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Normal_Rod = 37,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Hell_Slugger = 38,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Judge_Mace = 39,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Heavy_Steel_Pipe = 40,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_41 = 41,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Battle_Hammer = 42,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Wicked_Iron_Pipe = 43,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_44 = 44,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Heavy_Mace = 45,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Spike_Rod = 46,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_47 = 47,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Bush_Hammer = 48,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Demon_Pipe = 49,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_50 = 50,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Boss_Bush_Hammer = 51,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Gaea_Presser = 52,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_53 = 53,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Big_Sleep_Stick = 54,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Stun_Baton = 55,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_56 = 56,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Dragon_God_Pole = 57,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Grand_Presser = 58,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Armageddon_Rod = 59,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Super_Megido_Rod = 60,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_61 = 61,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_62 = 62,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_63 = 63,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Fervent_Bat = 64,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Ruyi_Jingu_Bang = 65,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_66 = 66,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Sleep_Stick = 67,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_68 = 68,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_69 = 69,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Gang_Star = 70,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_71 = 71,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Mjolnir = 72,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Bandit_Sword = 73,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Headhunter_Ladle = 74,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Lunar_Cutlass = 75,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Sonic_Blade = 76,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Scimitar = 77,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Talwar = 78,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_79 = 79,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Sleeper_Blade = 80,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Shamshir = 81,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Blood_Scimitar = 82,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Resting_Sword = 83,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Chiefs_Cutlass = 84,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_85 = 85,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Cosmic_Sword = 86,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Damascus_Sword = 87,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Hot_Blooded_Sword = 88,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Heavy_Saber = 89,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_90 = 90,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Panic_Sword = 91,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_92 = 92,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Bright_Sword = 93,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_94 = 94,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Answerer = 95,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_96 = 96,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_97 = 97,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Claiomh_Solais = 98,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_99 = 99,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_100 = 100,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_101 = 101,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_102 = 102,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_103 = 103,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_104 = 104,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            God_Saber = 105,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_106 = 106,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_107 = 107,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Leather_Whip = 108,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_109 = 109,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Skin_Ripper = 110,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Heat_Whip = 111,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Warrior_Whip = 112,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Decorative_Whip = 113,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Burn_Whip = 114,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Hero_Whip = 115,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_116 = 116,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Whip_Sword = 117,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Electromag_Whip = 118,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_119 = 119,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Mirage_Whip = 120,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Strike_Tail = 121,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_122 = 122,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Great_Whip_Sword = 123,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Chain_Whip = 124,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_125 = 125,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Fear_of_Pain = 126,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Spike_Whip = 127,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_128 = 128,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Hard_Branch = 129,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_130 = 130,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_131 = 131,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_132 = 132,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Guilty_Whip = 133,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Goat_Leather_Whip = 134,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_135 = 135,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_136 = 136,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_137 = 137,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_138 = 138,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Snow_Queens_Whip = 139,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_140 = 140,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Naraka_Whip = 141,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Katana = 142,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Gunto = 143,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Zandouto = 144,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Yuibitachi = 145,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Murasame = 146,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Antique_Gunto = 147,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Seishiki_Sword = 148,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Koedo_Sword = 149,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Jagato = 150,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Gekkou = 151,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_152 = 152,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_153 = 153,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Iai_Katana = 154,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_155 = 155,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Orochito = 156,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Wakizashi = 157,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_158 = 158,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Masamune = 159,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Masters_Iai_Katana = 160,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_161 = 161,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Red_Demon_Blade = 162,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_163 = 163,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Kaito_Ranma = 164,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_165 = 165,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Usumidori = 166,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_167 = 167,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_168 = 168,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Shikomi_Kiseru = 169,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_170 = 170,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Senryou_Yakusha = 171,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_172 = 172,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Brass_Knuckles = 173,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Hell_Knuckles = 174,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_175 = 175,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_176 = 176,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Metal_Duster = 177,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Old_Mans_Fist = 178,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Iron_Fist = 179,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Mach_Punch = 180,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_181 = 181,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Demon_Fist = 182,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Flash_Punch = 183,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_184 = 184,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Omega_Knuckle = 185,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Bout_Gloves = 186,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Sanction = 187,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_188 = 188,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_189 = 189,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_190 = 190,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_191 = 191,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Bear_Gloves = 192,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Clenched_Fist = 193,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Sabazios = 194,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_195 = 195,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_196 = 196,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Vajra = 197,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Disciplinary_Whip = 198,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Iron_Pipe = 199,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_200 = 200,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Axe = 201,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Mega_Axe = 202,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_203 = 203,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Crescent_Axe = 204,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_205 = 205,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Ice_Axe = 206,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_207 = 207,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Celtis = 208,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Kintaro_Axe = 209,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Amazon_Axe = 210,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_211 = 211,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_212 = 212,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_213 = 213,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Big_Bang_Axe = 214,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_215 = 215,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_216 = 216,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Gilgamesh_Axe = 217,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_218 = 218,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Fleurs_du_Mal = 219,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Knuckle_Duster = 220,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Delta_Knuckle = 221,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Heavy_Grip = 222,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Lumina_Saber = 223,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Hinokagutsuchi = 224,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Quasar_Saber = 225,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Hinokagutsuchi_II = 226,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Falchion = 227,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Masquerade_Ribbon = 228,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Fundo_Kusari = 229,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Death_Axe = 230,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_231 = 231,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_232 = 232,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Bardiche = 233,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Death_Contract = 234,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Black_Kogatana = 235,
            /// <summary>
            /// Useable by All (Dagger icon)
            /// </summary>
            RESERVE_236 = 236,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_237 = 237,
            /// <summary>
            /// Useable by All (Dagger icon)
            /// </summary>
            RESERVE_238 = 238,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_239 = 239,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Envy_Chain = 240,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Prophets_Hand = 241,
            /// <summary>
            /// Useable by All (Dagger icon)
            /// </summary>
            RESERVE_242 = 242,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Venture_Saber = 243,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_244 = 244,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Silver_Dagger = 245,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Saw_Saber = 246,
            /// <summary>
            /// Useable by Crow (Dagger icon)
            /// </summary>
            RESERVE_247 = 247,
            /// <summary>
            /// Useable by Crow (Dagger icon)
            /// </summary>
            RESERVE_248 = 248,
            /// <summary>
            /// Useable by Violet (Dagger icon)
            /// </summary>
            Kasumi_Awaken_Rapier = 249,
            /// <summary>
            /// Useable by Violet (Dagger icon)
            /// </summary>
            Kasumi_Aid_Rapier = 250,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            Rapier = 251,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            RESERVE_252 = 252,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            RESERVE_253 = 253,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            Sword_of_Sinai = 254,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            Sword_of_Sinai_II = 255,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            The_Great_Thief_Stick = 256,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Paradise_Lost_R = 257,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Imprisoned_Mjolnir = 258,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Fine_Ruyi_Jingu_Bang = 259,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Headhunter_Ladle_EX = 260,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Claiomh_Solais_R = 261,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Masquerade_Ribbon_R = 262,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Snow_Queens_Whip_II = 263,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Dainaraka_Whip = 264,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Senryou_Yakusha_R = 265,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Usumidori_R = 266,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Big_Bear_Gloves = 267,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Gordios = 268,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Unparalleled_Vajra = 269,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Death_Promise = 270,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Fleurs_du_Mal_R = 271,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Plasma_Knife = 272,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Arc_Mace = 273,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Megistos_Sword = 274,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Barog_Whip = 275,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Kaketsushinto = 276,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Meteor_Knuckle = 277,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Taiji_Axe = 278,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Dread_Saber = 279,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            White_Snow_Rapier = 280,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Punish_Dagger = 281,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Last_Hammer = 282,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Vertical_Edge = 283,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Grapnel = 284,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Ten_Ichimonji = 285,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Champion = 286,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Crusader = 287,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Guillotine_Saber = 288,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            Zirah_Bouk = 289,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Dark_Cutlass = 290,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Mut_Cutlass = 291,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Baccarat_Knuckle = 292,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Victory_Beam = 293,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            Decisive_Rapier = 294,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Infini_saber = 295,
            /// <summary>
            /// 
            /// </summary>
            BLANK_4096 = 4096,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4097 = 4097,
            /// <summary>
            /// Male - 
            /// </summary>
            Dark_Undershirt = 4098,
            /// <summary>
            /// Male - 
            /// </summary>
            Print_TShirt = 4099,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Neckerchief = 4100,
            /// <summary>
            /// Female - 
            /// </summary>
            Baseball_Jacket = 4101,
            /// <summary>
            /// Male - 
            /// </summary>
            Dress_Shirt = 4102,
            /// <summary>
            /// Female - 
            /// </summary>
            Turtleneck = 4103,
            /// <summary>
            /// Female - 
            /// </summary>
            Pink_Top = 4104,
            /// <summary>
            /// Female - 
            /// </summary>
            Loose_Cutsew = 4105,
            /// <summary>
            /// Male - 
            /// </summary>
            Formal_Shirt = 4106,
            /// <summary>
            /// Female - 
            /// </summary>
            Light_Undershirt = 4107,
            /// <summary>
            /// Male - 
            /// </summary>
            Chaos_Undershirt = 4108,
            /// <summary>
            /// Male - 
            /// </summary>
            RESERVE_4109 = 4109,
            /// <summary>
            /// Unisex - 
            /// </summary>
            Sooty_Ghastly_Gear = 4110,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4111 = 4111,
            /// <summary>
            /// Male - 
            /// </summary>
            Shoulder_Pads = 4112,
            /// <summary>
            /// Female - +Resist Forget
            /// </summary>
            Confident_Camisole = 4113,
            /// <summary>
            /// Unisex - +Resist Sleep
            /// </summary>
            Lynx_Camo_Vest = 4114,
            /// <summary>
            /// Morgana - +Resist Forget
            /// </summary>
            Memorial_Collar = 4115,
            /// <summary>
            /// Morgana - Ma+1
            /// </summary>
            Old_Cat_Collar = 4116,
            /// <summary>
            /// Morgana - Ma+3
            /// </summary>
            Cat_Knights_Collar = 4117,
            /// <summary>
            /// Male - +10 HP
            /// </summary>
            Old_Dukes_Coat = 4118,
            /// <summary>
            /// Male - +30 HP
            /// </summary>
            Dukes_Coat = 4119,
            /// <summary>
            /// Male - 
            /// </summary>
            RESERVE_4120 = 4120,
            /// <summary>
            /// Female - 
            /// </summary>
            RESERVE_4121 = 4121,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4122 = 4122,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Cat_Sweater = 4123,
            /// <summary>
            /// Female - +Evade Magic (low)
            /// </summary>
            Old_Angels_Cape = 4124,
            /// <summary>
            /// Female - +Evade Magic (med)
            /// </summary>
            Angels_Cape = 4125,
            /// <summary>
            /// Unisex - +Resist Sleep
            /// </summary>
            Old_Pajamas = 4126,
            /// <summary>
            /// Unisex - +Null Sleep
            /// </summary>
            Succubus_Pajamas = 4127,
            /// <summary>
            /// Male - +Resist Rage
            /// </summary>
            Saints_Tunic = 4128,
            /// <summary>
            /// Female - +Resist Freeze
            /// </summary>
            Robust_Apron = 4129,
            /// <summary>
            /// Unisex - +Evade Curse (low)
            /// </summary>
            Amulet_Shirt = 4130,
            /// <summary>
            /// Morgana - +Resist Rage
            /// </summary>
            Breeze_Scarf = 4131,
            /// <summary>
            /// Female - +Evade Magic (low)
            /// </summary>
            Silk_Dress = 4132,
            /// <summary>
            /// Female - +Evade Magic (med)
            /// </summary>
            Fine_Silk_Dress = 4133,
            /// <summary>
            /// Morgana - +20 SP
            /// </summary>
            Frost_Hood = 4134,
            /// <summary>
            /// Morgana - +40 SP
            /// </summary>
            Frost_Ace_Hood = 4135,
            /// <summary>
            /// Male - 
            /// </summary>
            Survival_Vest = 4136,
            /// <summary>
            /// Female - 
            /// </summary>
            Ladys_Dress = 4137,
            /// <summary>
            /// Unisex - +Ag+3
            /// </summary>
            Zen_Outfit = 4138,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Cone_Collar = 4139,
            /// <summary>
            /// Male - +Reduce Physical dmg (low)
            /// </summary>
            Old_Ghastly_Dress = 4140,
            /// <summary>
            /// Male - +Reduce Physical dmg (med)
            /// </summary>
            Shikigami_Dress = 4141,
            /// <summary>
            /// Female - Ag+1
            /// </summary>
            Old_Cheongsam = 4142,
            /// <summary>
            /// Female - Ag+3
            /// </summary>
            Fairy_Cheongsam = 4143,
            /// <summary>
            /// Morgana - Ag+1
            /// </summary>
            Old_Mythical_Scarf = 4144,
            /// <summary>
            /// Morgana - Ag+3
            /// </summary>
            Mythical_Scarf = 4145,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4146 = 4146,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4147 = 4147,
            /// <summary>
            /// Male - +Resist Confuse
            /// </summary>
            Cosmic_Undies = 4148,
            /// <summary>
            /// Female - +Resist Shock
            /// </summary>
            Lightning_Blouse = 4149,
            /// <summary>
            /// Unisex - +Resist Sleep
            /// </summary>
            Night_Shift_Haori = 4150,
            /// <summary>
            /// Morgana - +Resist Shock
            /// </summary>
            Rubber_Scarf = 4151,
            /// <summary>
            /// Female - Ma+4
            /// </summary>
            Heavensent_Dress = 4152,
            /// <summary>
            /// Female - Ma+6
            /// </summary>
            Godsent_Dress = 4153,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4154 = 4154,
            /// <summary>
            /// Morgana - 
            /// </summary>
            RESERVE_4155 = 4155,
            /// <summary>
            /// Male - 
            /// </summary>
            Athletic_Shirt = 4156,
            /// <summary>
            /// Female - 
            /// </summary>
            Power_Camisole = 4157,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4158 = 4158,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Hard_Scarf = 4159,
            /// <summary>
            /// Male - +En+1
            /// </summary>
            Old_Haori = 4160,
            /// <summary>
            /// Male - +En+5
            /// </summary>
            Dishonored_Haori = 4161,
            /// <summary>
            /// Morgana - +Evade Psy (med)
            /// </summary>
            Old_Coat = 4162,
            /// <summary>
            /// Morgana - +Evade Psy (high)
            /// </summary>
            Nekomata_Coat = 4163,
            /// <summary>
            /// Female - +10 HP
            /// </summary>
            Old_Fiery_Apron = 4164,
            /// <summary>
            /// Female - +30 HP
            /// </summary>
            Fiery_Apron = 4165,
            /// <summary>
            /// Male - +Ag+3
            /// </summary>
            Blood_Red_Capote = 4166,
            /// <summary>
            /// Male - +Ag+6
            /// </summary>
            Bloodied_Capote = 4167,
            /// <summary>
            /// Male - +Reduce Curse dmg (low)
            /// </summary>
            Mandala_Vest = 4168,
            /// <summary>
            /// Female - +Resist Fear
            /// </summary>
            Elysian_Robe = 4169,
            /// <summary>
            /// Unisex - +Evade Bless (low)
            /// </summary>
            Papal_Robes = 4170,
            /// <summary>
            /// Morgana - +Resist Fear
            /// </summary>
            Id_Collar = 4171,
            /// <summary>
            /// Male - 
            /// </summary>
            RESERVE_4172 = 4172,
            /// <summary>
            /// Female - 
            /// </summary>
            RESERVE_4173 = 4173,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4174 = 4174,
            /// <summary>
            /// Morgana - 
            /// </summary>
            RESERVE_4175 = 4175,
            /// <summary>
            /// Male - 
            /// </summary>
            Army_Vest = 4176,
            /// <summary>
            /// Female - 
            /// </summary>
            Hard_Corset = 4177,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4178 = 4178,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Sparkly_Collar = 4179,
            /// <summary>
            /// Male - +10 SP
            /// </summary>
            Old_Shroud = 4180,
            /// <summary>
            /// Male - +30 SP
            /// </summary>
            Royal_Holy_Shroud = 4181,
            /// <summary>
            /// Female - +10 SP
            /// </summary>
            Old_Robe = 4182,
            /// <summary>
            /// Female - +30 SP
            /// </summary>
            Arcane_Robe = 4183,
            /// <summary>
            /// Morgana - En+1
            /// </summary>
            Old_Snakeskin_Scarf = 4184,
            /// <summary>
            /// Morgana - En+5
            /// </summary>
            Snakeskin_Scarf = 4185,
            /// <summary>
            /// Male - Ma+4
            /// </summary>
            Fairy_Knight_Armor = 4186,
            /// <summary>
            /// Male - Ma+7
            /// </summary>
            Fairy_Hero_Armor = 4187,
            /// <summary>
            /// Male - +Resist Rage
            /// </summary>
            Cool_Vest = 4188,
            /// <summary>
            /// Female - +Resist Hunger
            /// </summary>
            Titanium_Corset = 4189,
            /// <summary>
            /// Unisex - +Resist Despair
            /// </summary>
            Hope_Shirt = 4190,
            /// <summary>
            /// Morgana - +Resist Rage
            /// </summary>
            Morose_Collar = 4191,
            /// <summary>
            /// Female - +Evade Wind (high)
            /// </summary>
            Tapsuan = 4192,
            /// <summary>
            /// Female - +Evade Wind (high)
            /// </summary>
            Fine_Tapsuan = 4193,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4194 = 4194,
            /// <summary>
            /// Morgana - 
            /// </summary>
            RESERVE_4195 = 4195,
            /// <summary>
            /// Male - 
            /// </summary>
            Gigas_Vest = 4196,
            /// <summary>
            /// Female - Ag+2
            /// </summary>
            Maillot = 4197,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4198 = 4198,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Armada_Collar = 4199,
            /// <summary>
            /// Female - +Resist Brainwash
            /// </summary>
            Old_Undershirt = 4200,
            /// <summary>
            /// Female - +Null Brainwash
            /// </summary>
            Lil_Devil_Undershirt = 4201,
            /// <summary>
            /// Morgana - +Reduce Elec dmg (low)
            /// </summary>
            Old_Shocking_Scarf = 4202,
            /// <summary>
            /// Morgana - +Reduce Elec dmg (med)
            /// </summary>
            Shocking_Scarf = 4203,
            /// <summary>
            /// Male - +Repel Physical (low)
            /// </summary>
            Old_Ghillie_Vest = 4204,
            /// <summary>
            /// Male - +Repel Physical (med)
            /// </summary>
            Ghillie_Vest = 4205,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4206 = 4206,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4207 = 4207,
            /// <summary>
            /// Male - +Resist Dizzy
            /// </summary>
            Austere_Haori = 4208,
            /// <summary>
            /// Female - +Resist Fear
            /// </summary>
            Yama_Dress = 4209,
            /// <summary>
            /// Unisex - +Evade Curse (low)
            /// </summary>
            Rune_Vest = 4210,
            /// <summary>
            /// Morgana - +Resist Fear
            /// </summary>
            Brave_Scarf = 4211,
            /// <summary>
            /// Female - Lu+5
            /// </summary>
            Lucky_Robe = 4212,
            /// <summary>
            /// Female - Lu+10
            /// </summary>
            Super_Lucky_Robe = 4213,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4214 = 4214,
            /// <summary>
            /// Morgana - 
            /// </summary>
            RESERVE_4215 = 4215,
            /// <summary>
            /// Male - 
            /// </summary>
            Fluted_Guard = 4216,
            /// <summary>
            /// Female - 
            /// </summary>
            Panzer_Dress = 4217,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4218 = 4218,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Measure_Collar = 4219,
            /// <summary>
            /// Male - St+1
            /// </summary>
            Old_Vest = 4220,
            /// <summary>
            /// Male - St+6
            /// </summary>
            Leopard_Print_Vest = 4221,
            /// <summary>
            /// Morgana - Lu+1
            /// </summary>
            Old_Pure_Collar = 4222,
            /// <summary>
            /// Morgana - Lu+6
            /// </summary>
            Pure_Collar = 4223,
            /// <summary>
            /// Female - En+1
            /// </summary>
            Old_Tights = 4224,
            /// <summary>
            /// Female - En+6
            /// </summary>
            Divine_Black_Tights = 4225,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4226 = 4226,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4227 = 4227,
            /// <summary>
            /// Male - +Resist Burn
            /// </summary>
            Fireman_Happi = 4228,
            /// <summary>
            /// Female - +Resist Dizzy
            /// </summary>
            Glaring_Cape = 4229,
            /// <summary>
            /// Unisex - +Resist Brainwash
            /// </summary>
            Egoist_Shirt = 4230,
            /// <summary>
            /// Morgana - +Resist Burn
            /// </summary>
            Water_Crown = 4231,
            /// <summary>
            /// Unisex - +Reduce Ice dmg (high)
            /// </summary>
            King_Frost_Cape = 4232,
            /// <summary>
            /// Unisex - +Reduce Ice dmg (high)
            /// </summary>
            King_Frost_Cape_EX = 4233,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4234 = 4234,
            /// <summary>
            /// Morgana - 
            /// </summary>
            RESERVE_4235 = 4235,
            /// <summary>
            /// Male - 
            /// </summary>
            Kaiser_Vest = 4236,
            /// <summary>
            /// Female - 
            /// </summary>
            Tomoes_Doumaru = 4237,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4238 = 4238,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Kampff_Collar = 4239,
            /// <summary>
            /// Morgana - +Evade Physical (low)
            /// </summary>
            Old_Wild_Lion_Scarf = 4240,
            /// <summary>
            /// Morgana - +Evade Physical (med)
            /// </summary>
            Wild_Lion_Scarf = 4241,
            /// <summary>
            /// Female - +Reduce Fire dmg (low)
            /// </summary>
            Old_Khamrai_Tao = 4242,
            /// <summary>
            /// Female - +Reduce Fire dmg (high)
            /// </summary>
            Khamrai_Tao = 4243,
            /// <summary>
            /// Male - Ag+1
            /// </summary>
            Old_Primate_Vest = 4244,
            /// <summary>
            /// Male - Ag+6
            /// </summary>
            Primate_Vest = 4245,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4246 = 4246,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4247 = 4247,
            /// <summary>
            /// Male - +Evade Bless (low)
            /// </summary>
            Demons_Jacket = 4248,
            /// <summary>
            /// Female - +Resist Freeze
            /// </summary>
            Cozy_Dress = 4249,
            /// <summary>
            /// Unisex - +Resist Forget
            /// </summary>
            Akashic_Shirt = 4250,
            /// <summary>
            /// Morgana - +Resist Freeze
            /// </summary>
            Lyrical_Scarf = 4251,
            /// <summary>
            /// Male - 
            /// </summary>
            RESERVE_4252 = 4252,
            /// <summary>
            /// Female - 
            /// </summary>
            RESERVE_4253 = 4253,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4254 = 4254,
            /// <summary>
            /// Morgana - 
            /// </summary>
            RESERVE_4255 = 4255,
            /// <summary>
            /// Male - 
            /// </summary>
            Karmas_Robe = 4256,
            /// <summary>
            /// Female - 
            /// </summary>
            Haten_Robe = 4257,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4258 = 4258,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Sublime_Collar = 4259,
            /// <summary>
            /// Female - +10 SP
            /// </summary>
            Old_Sinful_Bikini = 4260,
            /// <summary>
            /// Female - +50 SP
            /// </summary>
            Sinful_Bikini = 4261,
            /// <summary>
            /// Male - +10 HP
            /// </summary>
            Old_Underwear = 4262,
            /// <summary>
            /// Male - +50 HP
            /// </summary>
            Lucky_Underwear = 4263,
            /// <summary>
            /// Morgana - +10 HP
            /// </summary>
            Old_Infinity_Scarf = 4264,
            /// <summary>
            /// Morgana - +50 HP
            /// </summary>
            Bottomless_Scarf = 4265,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4266 = 4266,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4267 = 4267,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4268 = 4268,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4269 = 4269,
            /// <summary>
            /// Morgana - Regenerate 2
            /// </summary>
            Scarf_of_Mercy = 4270,
            /// <summary>
            /// Morgana - 
            /// </summary>
            RESERVE_4271 = 4271,
            /// <summary>
            /// Male - 
            /// </summary>
            RESERVE_4272 = 4272,
            /// <summary>
            /// Female - 
            /// </summary>
            RESERVE_4273 = 4273,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4274 = 4274,
            /// <summary>
            /// Morgana - 
            /// </summary>
            RESERVE_4275 = 4275,
            /// <summary>
            /// Male - +30 HP
            /// </summary>
            Immortal_Vest = 4276,
            /// <summary>
            /// Female - 
            /// </summary>
            RESERVE_4277 = 4277,
            /// <summary>
            /// Male - Ma+1
            /// </summary>
            Old_Black_Tights = 4278,
            /// <summary>
            /// Male - Ma+8
            /// </summary>
            Deaths_Black_Tights = 4279,
            /// <summary>
            /// Female - Ma+1
            /// </summary>
            Old_Witchs_Robe = 4280,
            /// <summary>
            /// Female - Ma+8
            /// </summary>
            Lovely_Witchs_Robe = 4281,
            /// <summary>
            /// Morgana - +Reduce Physical dmg (low)
            /// </summary>
            Old_Scale_Scarf = 4282,
            /// <summary>
            /// Morgana - +Reduce Physical dmg (high)
            /// </summary>
            Dragon_Scale_Scarf = 4283,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4284 = 4284,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4285 = 4285,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4286 = 4286,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4287 = 4287,
            /// <summary>
            /// Male - +Reduce Magic dmg (high)
            /// </summary>
            Tantric_Oath = 4288,
            /// <summary>
            /// Male - Prevents Curse instakills
            /// </summary>
            Black_Jacket = 4289,
            /// <summary>
            /// Male - +Evade Curse (high)
            /// </summary>
            Officials_Robe = 4290,
            /// <summary>
            /// Male - +Reduce Magic dmg (high)
            /// </summary>
            Tantric_Oath_R = 4291,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4292 = 4292,
            /// <summary>
            /// Female - +Reduce Elec dmg (high)
            /// </summary>
            Archangel_Bra = 4293,
            /// <summary>
            /// Female - 
            /// </summary>
            RESERVE_4294 = 4294,
            /// <summary>
            /// Female - +Reduce Elec dmg (high)
            /// </summary>
            High_Archangel_Bra = 4295,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4296 = 4296,
            /// <summary>
            /// Unisex - +Reduce Nuke dmg (med)
            /// </summary>
            Black_Wing_Robe = 4297,
            /// <summary>
            /// Unisex - +Reduce Nuke dmg (high)
            /// </summary>
            Black_Wing_Robe_R = 4298,
            /// <summary>
            /// Male - Prevents Curse instakills
            /// </summary>
            Dark_Jacket = 4299,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4300 = 4300,
            /// <summary>
            /// Male - +Evade Curse (high)
            /// </summary>
            Officials_Robe_R = 4301,
            /// <summary>
            /// Male - 
            /// </summary>
            Black_Robe = 4302,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4303 = 4303,
            /// <summary>
            /// Female - +Repel Physical (high)
            /// </summary>
            Moonlight_Robe_R = 4304,
            /// <summary>
            /// Unisex - +Null Fear
            /// </summary>
            Weird_Wrap = 4305,
            /// <summary>
            /// Female - +Repel Physical (high)
            /// </summary>
            Moonlight_Robe = 4306,
            /// <summary>
            /// Unisex - +Reduce Magic dmg (high)
            /// </summary>
            Sirius_Armor = 4307,
            /// <summary>
            /// Unisex - +Reduce Magic dmg (high)
            /// </summary>
            Sirius_Armor_EX = 4308,
            /// <summary>
            /// Female - 
            /// </summary>
            Sooty_Ladies_Armor = 4309,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Sooty_Boots = 4310,
            /// <summary>
            /// Male - 
            /// </summary>
            Sooty_Heavy_Armor = 4311,
            /// <summary>
            /// Male - 
            /// </summary>
            Sooty_Yorishiro = 4312,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Sooty_Elders_Armor = 4313,
            /// <summary>
            /// Female - 
            /// </summary>
            Sooty_Cheongsam = 4314,
            /// <summary>
            /// Male - 
            /// </summary>
            Sooty_Mans_Armor = 4315,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Sooty_Cats_Armor = 4316,
            /// <summary>
            /// Female - 
            /// </summary>
            Sooty_Ogress_Gear = 4317,
            /// <summary>
            /// Male - 
            /// </summary>
            Sooty_Wolfs_Coat = 4318,
            /// <summary>
            /// Female - 
            /// </summary>
            Sooty_Divine_Armor = 4319,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Sooty_Snakeskin = 4320,
            /// <summary>
            /// Female - 
            /// </summary>
            Sooty_Astro_Armor = 4321,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Sooty_Feather_Coat = 4322,
            /// <summary>
            /// Male - 
            /// </summary>
            Sooty_Black_Armor = 4323,
            /// <summary>
            /// Male - 
            /// </summary>
            Sooty_Spotted_Fur = 4324,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Sooty_Horn = 4325,
            /// <summary>
            /// Female - 
            /// </summary>
            Sooty_Grifters_Garb = 4326,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Sooty_Lions_Mane = 4327,
            /// <summary>
            /// Male - 
            /// </summary>
            Sooty_Monkey_Fur = 4328,
            /// <summary>
            /// Female - 
            /// </summary>
            Sooty_Regalia = 4329,
            /// <summary>
            /// Female - 
            /// </summary>
            Sooty_Rogues_Garb = 4330,
            /// <summary>
            /// Male - 
            /// </summary>
            Sooty_Bolt_Armor = 4331,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Sooty_Gilded_Collar = 4332,
            /// <summary>
            /// Male - 
            /// </summary>
            Sooty_Dancers_Garb = 4333,
            /// <summary>
            /// Female - 
            /// </summary>
            Sooty_Dark_Armor = 4334,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Sooty_Scale_Armor = 4335,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4336 = 4336,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4337 = 4337,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4338 = 4338,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4339 = 4339,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4340 = 4340,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4341 = 4341,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4342 = 4342,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4343 = 4343,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4344 = 4344,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4345 = 4345,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4346 = 4346,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4347 = 4347,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4348 = 4348,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4349 = 4349,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4350 = 4350,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4351 = 4351,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4352 = 4352,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4353 = 4353,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4354 = 4354,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4355 = 4355,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4356 = 4356,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4357 = 4357,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4358 = 4358,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4359 = 4359,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4360 = 4360,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4361 = 4361,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4362 = 4362,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4363 = 4363,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_4364 = 4364,
            /// <summary>
            /// Male - +Resist Dizzy
            /// </summary>
            Shining_Vest = 4365,
            /// <summary>
            /// Female - +Resist Brainwash
            /// </summary>
            Tao_Robe = 4366,
            /// <summary>
            /// Morgana - +Resist Brainwash
            /// </summary>
            Philosophical_Scarf = 4367,
            /// <summary>
            /// Unisex - +Resist Fear
            /// </summary>
            Bodhi_Haori = 4368,
            /// <summary>
            /// Male - 
            /// </summary>
            Divine_Guard = 4369,
            /// <summary>
            /// Female - 
            /// </summary>
            Unio_Dress = 4370,
            /// <summary>
            /// Morgana - 
            /// </summary>
            Pleroma_Collar = 4371,
            /// <summary>
            /// Unisex - 
            /// </summary>
            RESERVE_4372 = 4372,
            /// <summary>
            /// Male - Lu+5
            /// </summary>
            Gamblers_Shirt = 4373,
            /// <summary>
            /// Unisex - +Repel Physical (low)
            /// </summary>
            Immovable_Shirt = 4374,
            /// <summary>
            /// Unisex - +50 HP
            /// </summary>
            Vest_of_Life = 4375,
            /// <summary>
            /// Female - 
            /// </summary>
            RESERVE_4376 = 4376,
            /// <summary>
            /// Morgana - 
            /// </summary>
            RESERVE_4377 = 4377,
            /// <summary>
            /// Male - +Resist Sleep
            /// </summary>
            Nightwatch_Armor = 4378,
            /// <summary>
            /// Unisex - En+3
            /// </summary>
            Golden_Vest = 4379,
            /// <summary>
            /// Female - Prevents Curse instakills
            /// </summary>
            Robe_of_Hatred = 4380,
            /// <summary>
            /// Unisex - 
            /// </summary>
            Space_Suit = 4381,
            /// <summary>
            /// Female - Ag+5
            /// </summary>
            Golden_Dress = 4382,
            /// <summary>
            /// Male - Ma+5
            /// </summary>
            Starry_Wisdom_Vest = 4383,
            /// <summary>
            /// 
            /// </summary>
            _0x120 = 4384,
            /// <summary>
            /// 
            /// </summary>
            _0x121 = 4385,
            /// <summary>
            /// 
            /// </summary>
            _0x122 = 4386,
            /// <summary>
            /// 
            /// </summary>
            _0x123 = 4387,
            /// <summary>
            /// 
            /// </summary>
            _0x124 = 4388,
            /// <summary>
            /// 
            /// </summary>
            _0x125 = 4389,
            /// <summary>
            /// 
            /// </summary>
            _0x126 = 4390,
            /// <summary>
            /// 
            /// </summary>
            _0x127 = 4391,
            /// <summary>
            /// 
            /// </summary>
            _0x128 = 4392,
            /// <summary>
            /// 
            /// </summary>
            _0x129 = 4393,
            /// <summary>
            /// 
            /// </summary>
            _0x12A = 4394,
            /// <summary>
            /// 
            /// </summary>
            BLANK_8192 = 8192,
            /// <summary>
            /// ---- - 
            /// </summary>
            Hip_Glasses = 8193,
            /// <summary>
            /// ---- - 
            /// </summary>
            Suspenders = 8194,
            /// <summary>
            /// ---- - 
            /// </summary>
            Fanny_Pack = 8195,
            /// <summary>
            /// ---- - 
            /// </summary>
            Hairpin = 8196,
            /// <summary>
            /// ---- - 
            /// </summary>
            Silver_Key_Ring = 8197,
            /// <summary>
            /// ---- - 
            /// </summary>
            Black_Tights = 8198,
            /// <summary>
            /// ---- - 
            /// </summary>
            Dotted_Tights = 8199,
            /// <summary>
            /// ---- - 
            /// </summary>
            Headphones = 8200,
            /// <summary>
            /// ---- - 
            /// </summary>
            Black_Necktie = 8201,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8202 = 8202,
            /// <summary>
            /// Life Bonus - 
            /// </summary>
            Breath_Ring = 8203,
            /// <summary>
            /// Life Gain - 
            /// </summary>
            Energy_Ring = 8204,
            /// <summary>
            /// Life Surge - 
            /// </summary>
            Ring_of_Vitality = 8205,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8206 = 8206,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8207 = 8207,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8208 = 8208,
            /// <summary>
            /// Mana Bonus - 
            /// </summary>
            Chakra_Choker = 8209,
            /// <summary>
            /// Mana Gain - 
            /// </summary>
            Mind_Choker = 8210,
            /// <summary>
            /// Mana Surge - 
            /// </summary>
            Soul_Choker = 8211,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8212 = 8212,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8213 = 8213,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8214 = 8214,
            /// <summary>
            /// Fire Boost - 
            /// </summary>
            Red_Band = 8215,
            /// <summary>
            /// Ice Boost - 
            /// </summary>
            Blue_Band = 8216,
            /// <summary>
            /// Wind Boost - 
            /// </summary>
            Green_Band = 8217,
            /// <summary>
            /// Elec Boost - 
            /// </summary>
            Yellow_Band = 8218,
            /// <summary>
            /// Fire Amp - 
            /// </summary>
            Lantern_Necklace = 8219,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8220 = 8220,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8221 = 8221,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8222 = 8222,
            /// <summary>
            /// Nuke Boost - 
            /// </summary>
            Star_Bracelet = 8223,
            /// <summary>
            /// Psy Boost - 
            /// </summary>
            Circular_Band = 8224,
            /// <summary>
            /// Bless Boost - 
            /// </summary>
            White_Band = 8225,
            /// <summary>
            /// Curse Boost - 
            /// </summary>
            Black_Band = 8226,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8227 = 8227,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8228 = 8228,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8229 = 8229,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8230 = 8230,
            /// <summary>
            /// Rage Atk Up - 
            /// </summary>
            Raging_Wristband = 8231,
            /// <summary>
            /// Ailment Boost - 
            /// </summary>
            Eccentric_Belt = 8232,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8233 = 8233,
            /// <summary>
            /// Fast Heal - 
            /// </summary>
            Magnetic_Necklace = 8234,
            /// <summary>
            /// InstaHeal - 
            /// </summary>
            PickMeUp_Tie = 8235,
            /// <summary>
            /// Unshaken Will - 
            /// </summary>
            Sturdy_Suspenders = 8236,
            /// <summary>
            /// Resist Phys - 
            /// </summary>
            Strength_Belt = 8237,
            /// <summary>
            /// Resist Burn - 
            /// </summary>
            Wood_Clappers = 8238,
            /// <summary>
            /// Resist Freeze - 
            /// </summary>
            Hot_Water_Pouch = 8239,
            /// <summary>
            /// Resist Shock - 
            /// </summary>
            Rubber_Gloves = 8240,
            /// <summary>
            /// Resist Dizzy - 
            /// </summary>
            Shield_Goggles = 8241,
            /// <summary>
            /// Resist Confuse - 
            /// </summary>
            Calming_Mask = 8242,
            /// <summary>
            /// Resist Fear - 
            /// </summary>
            Wooden_Clogs = 8243,
            /// <summary>
            /// Resist Forget - 
            /// </summary>
            Notebook = 8244,
            /// <summary>
            /// Null Hunger - 
            /// </summary>
            WellFed_Cape = 8245,
            /// <summary>
            /// Null Sleep - 
            /// </summary>
            Sleepless_Gem = 8246,
            /// <summary>
            /// Null Rage - 
            /// </summary>
            Calming_Cape = 8247,
            /// <summary>
            /// Null Despair - 
            /// </summary>
            Cape_of_Hope = 8248,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8249 = 8249,
            /// <summary>
            /// Resist Brainwash - 
            /// </summary>
            Brain_Guard = 8250,
            /// <summary>
            /// Null Burn - 
            /// </summary>
            Burn_Charm = 8251,
            /// <summary>
            /// Null Freeze - 
            /// </summary>
            Freeze_Charm = 8252,
            /// <summary>
            /// Apt Pupil - 
            /// </summary>
            Grand_Slam_Charm = 8253,
            /// <summary>
            /// Null Shock - 
            /// </summary>
            Shockproof_Charm = 8254,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8255 = 8255,
            /// <summary>
            /// Null Fear - 
            /// </summary>
            Fearless_Cape = 8256,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8257 = 8257,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8258 = 8258,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8259 = 8259,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8260 = 8260,
            /// <summary>
            /// Null Despair - 
            /// </summary>
            Despair_Charm = 8261,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8262 = 8262,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8263 = 8263,
            /// <summary>
            /// Counter - 
            /// </summary>
            Revenge_Mirror = 8264,
            /// <summary>
            /// Counterstrike - 
            /// </summary>
            Reprisal_Mirror = 8265,
            /// <summary>
            /// High Counter - 
            /// </summary>
            Retribution_Mirror = 8266,
            /// <summary>
            /// Resist Sleep - 
            /// </summary>
            Caffeine_Patch = 8267,
            /// <summary>
            /// Resist Rage - 
            /// </summary>
            Peaceful_Potpourri = 8268,
            /// <summary>
            /// Resist Despair - 
            /// </summary>
            Positivity_Calendar = 8269,
            /// <summary>
            /// Null Dizzy - 
            /// </summary>
            Designer_Shades = 8270,
            /// <summary>
            /// Null Confuse - 
            /// </summary>
            Clarity_Cape = 8271,
            /// <summary>
            /// Burn Boost - 
            /// </summary>
            Oil_Pack = 8272,
            /// <summary>
            /// Freeze Boost - 
            /// </summary>
            Cooling_Pack = 8273,
            /// <summary>
            /// Shock Boost - 
            /// </summary>
            Portable_Battery = 8274,
            /// <summary>
            /// Dizzy Boost - 
            /// </summary>
            Dizzy_Mask = 8275,
            /// <summary>
            /// Confuse Boost - 
            /// </summary>
            Mysterious_Mask = 8276,
            /// <summary>
            /// Fear Boost - 
            /// </summary>
            Sinister_Mask = 8277,
            /// <summary>
            /// Forget Boost - 
            /// </summary>
            Forgetful_Mask = 8278,
            /// <summary>
            /// Sleep Boost - 
            /// </summary>
            Drowsy_Mask = 8279,
            /// <summary>
            /// Rage Boost - 
            /// </summary>
            Clown_Mask = 8280,
            /// <summary>
            /// Despair Boost - 
            /// </summary>
            Corrupting_Mask = 8281,
            /// <summary>
            /// Brainwash Boost - 
            /// </summary>
            Occult_Mask = 8282,
            /// <summary>
            /// Champion's Cup - Cost 10 SP
            /// </summary>
            Ring_of_Lust = 8283,
            /// <summary>
            /// Bleeding Dry Brush - Cost 22 SP
            /// </summary>
            Ring_of_Vanity = 8284,
            /// <summary>
            /// Vault Guardian - Cost 20 SP
            /// </summary>
            Ring_of_Gluttony = 8285,
            /// <summary>
            /// Wings of Wisdom - Cost 10 SP
            /// </summary>
            Ring_of_Wrath = 8286,
            /// <summary>
            /// President's Insight - Cost 15 SP
            /// </summary>
            Ring_of_Greed = 8287,
            /// <summary>
            /// Gambler's Foresight - Cost 20 SP
            /// </summary>
            Ring_of_Envy = 8288,
            /// <summary>
            /// Tyrant's Will - Cost 15 SP
            /// </summary>
            Ring_of_Pride = 8289,
            /// <summary>
            /// Guiding Tendril - Cost 20 SP
            /// </summary>
            Ring_of_Sorrow = 8290,
            /// <summary>
            /// Diarama - Cost 6 SP
            /// </summary>
            Crystal_of_Lust = 8291,
            /// <summary>
            /// Brush of Vanity - 
            /// </summary>
            Crystal_of_Vanity = 8292,
            /// <summary>
            /// Marakukaja - Cost 24 SP
            /// </summary>
            Crystal_of_Gluttony = 8293,
            /// <summary>
            /// Speed Master - 
            /// </summary>
            Crystal_of_Wrath = 8294,
            /// <summary>
            /// Attack Master - 
            /// </summary>
            Crystal_of_Greed = 8295,
            /// <summary>
            /// Masukukaja - Cost 24 SP
            /// </summary>
            Crystal_of_Envy = 8296,
            /// <summary>
            /// Defense Master - 
            /// </summary>
            Crystal_of_Pride = 8297,
            /// <summary>
            /// Life Aid - 
            /// </summary>
            Crystal_of_Sorrow = 8298,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8299 = 8299,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8300 = 8300,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8301 = 8301,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8302 = 8302,
            /// <summary>
            /// Attack Master - 
            /// </summary>
            Rakshasa_Belt = 8303,
            /// <summary>
            /// Defense Master - 
            /// </summary>
            Varja_Belt = 8304,
            /// <summary>
            /// Speed Master - 
            /// </summary>
            Skanda_Belt = 8305,
            /// <summary>
            /// Sharp Student - 
            /// </summary>
            Ace_Cap = 8306,
            /// <summary>
            /// Counter - 
            /// </summary>
            Willful_Belt = 8307,
            /// <summary>
            /// Fortified Moxy - 
            /// </summary>
            Lure_Keychain = 8308,
            /// <summary>
            /// Arms Master - 
            /// </summary>
            Bravery_Sash = 8309,
            /// <summary>
            /// Spell Master - 
            /// </summary>
            Magic_Misanga = 8310,
            /// <summary>
            /// Null Brainwash - Ag+5
            /// </summary>
            Hades_Harp = 8311,
            /// <summary>
            /// Null Brainwash - Ag+8
            /// </summary>
            Hades_Harp_R = 8312,
            /// <summary>
            /// Evade Curse - Ma+5
            /// </summary>
            Darkness_Ring = 8313,
            /// <summary>
            /// Evade Curse - Ma+8
            /// </summary>
            Darkness_Ring_R = 8314,
            /// <summary>
            /// Life Surge - En+5
            /// </summary>
            White_Headband = 8315,
            /// <summary>
            /// Life Surge - En+8
            /// </summary>
            White_Headband_R = 8316,
            /// <summary>
            /// Mana Surge - St+5
            /// </summary>
            Black_Headband = 8317,
            /// <summary>
            /// Mana Surge - St+8
            /// </summary>
            Black_Headband_R = 8318,
            /// <summary>
            /// Attack Master - Lu+10
            /// </summary>
            Red_String = 8319,
            /// <summary>
            /// Attack Master - Lu+13
            /// </summary>
            Red_String_R = 8320,
            /// <summary>
            /// Fire Amp - En+10
            /// </summary>
            Blazing_Horn = 8321,
            /// <summary>
            /// Fire Amp - En+13
            /// </summary>
            Inferno_Horn = 8322,
            /// <summary>
            /// Apt Pupil - St+5
            /// </summary>
            Black_Moon = 8323,
            /// <summary>
            /// Apt Pupil - St+8
            /// </summary>
            Black_Moon_R = 8324,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8325 = 8325,
            /// <summary>
            /// Null Brainwash - Ma+5
            /// </summary>
            Graceful_Harp = 8326,
            /// <summary>
            /// Null Brainwash - Ma+8
            /// </summary>
            Graceful_Harp_R = 8327,
            /// <summary>
            /// AutoMaraku - En+5
            /// </summary>
            Kugelbein = 8328,
            /// <summary>
            /// AutoMaraku - En+8
            /// </summary>
            Kugelbein_R = 8329,
            /// <summary>
            /// Invigorate 3 - All stats+2
            /// </summary>
            Shiny_Belt = 8330,
            /// <summary>
            /// Invigorate 3 - All stats+3
            /// </summary>
            Shiny_Belt_R = 8331,
            /// <summary>
            /// InstaHeal - All stats+2
            /// </summary>
            Picaresque_Hat = 8332,
            /// <summary>
            /// InstaHeal - All stats+3
            /// </summary>
            Picaresque_Crown = 8333,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8334 = 8334,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8335 = 8335,
            /// <summary>
            /// Dodge Phys - 
            /// </summary>
            Bold_Eyepatch = 8336,
            /// <summary>
            /// Evade Phys - 
            /// </summary>
            Compression_Socks = 8337,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8338 = 8338,
            /// <summary>
            /// Dodge Fire - 
            /// </summary>
            Fireproof_Choker = 8339,
            /// <summary>
            /// Evade Fire - 
            /// </summary>
            Fireproof_Bracelet = 8340,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8341 = 8341,
            /// <summary>
            /// Dodge Ice - 
            /// </summary>
            Iceproof_Choker = 8342,
            /// <summary>
            /// Evade Ice - 
            /// </summary>
            Iceproof_Bracelet = 8343,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8344 = 8344,
            /// <summary>
            /// Dodge Elec - 
            /// </summary>
            Elecproof_Choker = 8345,
            /// <summary>
            /// Evade Elec - 
            /// </summary>
            Elecproof_Bracelet = 8346,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8347 = 8347,
            /// <summary>
            /// Dodge Wind - 
            /// </summary>
            Windproof_Choker = 8348,
            /// <summary>
            /// Evade Wind - 
            /// </summary>
            Windproof_Bracelet = 8349,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8350 = 8350,
            /// <summary>
            /// Dodge Nuke - 
            /// </summary>
            Nukeproof_Choker = 8351,
            /// <summary>
            /// Evade Nuke - 
            /// </summary>
            Nukeproof_Bracelet = 8352,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8353 = 8353,
            /// <summary>
            /// Dodge Psy - 
            /// </summary>
            Psyproof_Choker = 8354,
            /// <summary>
            /// Evade Psy - 
            /// </summary>
            Psyproof_Bracelet = 8355,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8356 = 8356,
            /// <summary>
            /// Dodge Bless - 
            /// </summary>
            Blessproof_Choker = 8357,
            /// <summary>
            /// Evade Bless - 
            /// </summary>
            Blessproof_Bracelet = 8358,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8359 = 8359,
            /// <summary>
            /// Dodge Curse - 
            /// </summary>
            Curseproof_Choker = 8360,
            /// <summary>
            /// Evade Curse - 
            /// </summary>
            Apotropaic_Hairpin = 8361,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8362 = 8362,
            /// <summary>
            /// Angelic Grace - 
            /// </summary>
            Angel_Badge = 8363,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8364 = 8364,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8365 = 8365,
            /// <summary>
            /// +50% EXP - 
            /// </summary>
            Expedite_Ring = 8366,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8367 = 8367,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8368 = 8368,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8369 = 8369,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8370 = 8370,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8371 = 8371,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8372 = 8372,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8373 = 8373,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8374 = 8374,
            /// <summary>
            /// Attack Master - St+3
            /// </summary>
            Regent = 8375,
            /// <summary>
            /// Mana Bonus - All stats+1
            /// </summary>
            Queens_Necklace = 8376,
            /// <summary>
            /// Dodge Phys - En+3
            /// </summary>
            Stone_of_Scone = 8377,
            /// <summary>
            /// Bless Amp - All stats+2
            /// </summary>
            KohiNoor = 8378,
            /// <summary>
            /// High Counter - En+3
            /// </summary>
            Orlov = 8379,
            /// <summary>
            /// AutoMataru - En+5
            /// </summary>
            Emperors_Charm = 8380,
            /// <summary>
            /// Regenerate 3 - All stats+3
            /// </summary>
            Hope_Diamond = 8381,
            /// <summary>
            /// Angelic Grace - All stats+5
            /// </summary>
            Crystal_Skull = 8382,
            /// <summary>
            /// Hama Boost - 
            /// </summary>
            CrossShaped_Charm = 8383,
            /// <summary>
            /// AutoMataru - 
            /// </summary>
            Umi_Sachihikos_Belt = 8384,
            /// <summary>
            /// AutoMasuku - 
            /// </summary>
            Idatens_Belt = 8385,
            /// <summary>
            /// AutoMaraku - 
            /// </summary>
            Hall_of_Fame_Belt = 8386,
            /// <summary>
            /// Null Brainwash - 
            /// </summary>
            Thief_Mask = 8387,
            /// <summary>
            /// 
            /// </summary>
            Black_Rock = 8388,
            /// <summary>
            /// Mudo Boost - 
            /// </summary>
            Skull_Charm = 8389,
            /// <summary>
            /// Fire Amp - 
            /// </summary>
            Crimson_Necklace = 8390,
            /// <summary>
            /// Ice Amp - 
            /// </summary>
            Silver_Ice_Necklace = 8391,
            /// <summary>
            /// Wind Amp - 
            /// </summary>
            Jade_Wind_Necklace = 8392,
            /// <summary>
            /// Elec Amp - 
            /// </summary>
            Purple_Bolt_Necklace = 8393,
            /// <summary>
            /// Nuke Amp - 
            /// </summary>
            Atom_Necklace = 8394,
            /// <summary>
            /// Psy Amp - 
            /// </summary>
            Psy_Necklace = 8395,
            /// <summary>
            /// Bless Amp - 
            /// </summary>
            Heavenly_Necklace = 8396,
            /// <summary>
            /// Curse Amp - 
            /// </summary>
            Night_Necklace = 8397,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8398 = 8398,
            /// <summary>
            /// Mana Gain - 
            /// </summary>
            Menehune_Dolls = 8399,
            /// <summary>
            /// Evade Bless - 
            /// </summary>
            Hawaiian_Ring = 8400,
            /// <summary>
            /// Ice Amp - 
            /// </summary>
            Forneus_Badge = 8401,
            /// <summary>
            /// Elec Amp - 
            /// </summary>
            Train_Badge = 8402,
            /// <summary>
            /// Nuke Amp - 
            /// </summary>
            PI_Badge = 8403,
            /// <summary>
            /// Evade Fire - 
            /// </summary>
            Punch_Badge = 8404,
            /// <summary>
            /// Evade Elec - 
            /// </summary>
            Gambla_Badge = 8405,
            /// <summary>
            /// Psy Amp - 
            /// </summary>
            Golfer_Badge = 8406,
            /// <summary>
            /// Defense Master - 
            /// </summary>
            Tough_Belt = 8407,
            /// <summary>
            /// Counterstrike - 
            /// </summary>
            Dandy_Mirror = 8408,
            /// <summary>
            /// Null Sleep - 
            /// </summary>
            Leblanc_Charm = 8409,
            /// <summary>
            /// Endure - 
            /// </summary>
            Boss_Undies = 8410,
            /// <summary>
            /// Life Bonus - 
            /// </summary>
            _2nd_Mate_Badge = 8411,
            /// <summary>
            /// Life Gain - 
            /// </summary>
            _1st_Mate_Badge = 8412,
            /// <summary>
            /// Life Surge - 
            /// </summary>
            Captain_Badge = 8413,
            /// <summary>
            /// Regenerate 1 - 
            /// </summary>
            Regen_Patch_1 = 8414,
            /// <summary>
            /// Regenerate 2 - 
            /// </summary>
            Regen_Patch_2 = 8415,
            /// <summary>
            /// Regenerate 3 - 
            /// </summary>
            Regen_Patch_3 = 8416,
            /// <summary>
            /// Invigorate 1 - 
            /// </summary>
            SP_Adhesive_1 = 8417,
            /// <summary>
            /// Invigorate 2 - 
            /// </summary>
            SP_Adhesive_2 = 8418,
            /// <summary>
            /// Invigorate 3 - 
            /// </summary>
            SP_Adhesive_3 = 8419,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8420 = 8420,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8421 = 8421,
            /// <summary>
            /// Victory Cry - 
            /// </summary>
            The_Victory_Cup = 8422,
            /// <summary>
            /// Ali Dance - 
            /// </summary>
            Fish_Gods_Badge = 8423,
            /// <summary>
            /// Zenith Defense - 
            /// </summary>
            Omnipotent_Orb = 8424,
            /// <summary>
            /// Firm Stance - 
            /// </summary>
            Divine_Pillar = 8425,
            /// <summary>
            /// Not Found by Enemy - 
            /// </summary>
            Invisible_Veil = 8426,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8427 = 8427,
            /// <summary>
            /// Null Forget - 
            /// </summary>
            Attachment_Pearl = 8428,
            /// <summary>
            /// Ambient Aid - 
            /// </summary>
            Nuisance_Belt = 8429,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8430 = 8430,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8431 = 8431,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8432 = 8432,
            /// <summary>
            /// ---- - 
            /// </summary>
            Holy_Stone = 8433,
            /// <summary>
            /// +15% EXP - 
            /// </summary>
            Team_Glasses = 8434,
            /// <summary>
            /// Money Boost - 
            /// </summary>
            SEES_Armband = 8435,
            /// <summary>
            /// Hide - 
            /// </summary>
            Sevens_Emblem = 8436,
            /// <summary>
            /// Null Bless/Curse - 
            /// </summary>
            St_Hermelin_Badge = 8437,
            /// <summary>
            /// Life Boost - All stats+3
            /// </summary>
            ARM_PC = 8438,
            /// <summary>
            /// AllOut Attack Boost - 
            /// </summary>
            Midnight_Bandana = 8439,
            /// <summary>
            /// Gun Accuracy +5% - 
            /// </summary>
            Evoker = 8440,
            /// <summary>
            /// Evade Curse - 
            /// </summary>
            Honu_Charm = 8441,
            /// <summary>
            /// Divine Grace - 
            /// </summary>
            Tiki_Keychain = 8442,
            /// <summary>
            /// ---- - 
            /// </summary>
            Beast_Headphones = 8443,
            /// <summary>
            /// ---- - 
            /// </summary>
            Babel_Headphones = 8444,
            /// <summary>
            /// Foritify Spirit - 
            /// </summary>
            Lambs_Pillow = 8445,
            /// <summary>
            /// Samurai Spirit - 
            /// </summary>
            Gauntlet = 8446,
            /// <summary>
            /// Kuzunoha Emblem - 
            /// </summary>
            Kuzunoha_Tubes = 8447,
            /// <summary>
            /// Wind Amp - 
            /// </summary>
            Featherman_Badge = 8448,
            /// <summary>
            /// ---- - 
            /// </summary>
            Fire_Augite = 8449,
            /// <summary>
            /// ---- - 
            /// </summary>
            Ice_Augite = 8450,
            /// <summary>
            /// ---- - 
            /// </summary>
            Lightning_Augite = 8451,
            /// <summary>
            /// ---- - 
            /// </summary>
            Wind_Augite = 8452,
            /// <summary>
            /// ---- - 
            /// </summary>
            Psy_Augite = 8453,
            /// <summary>
            /// ---- - 
            /// </summary>
            Nuclear_Augite = 8454,
            /// <summary>
            /// ---- - 
            /// </summary>
            Cross_Augite = 8455,
            /// <summary>
            /// ---- - 
            /// </summary>
            Skeleton_Augite = 8456,
            /// <summary>
            /// ---- - 
            /// </summary>
            Healing_Augite = 8457,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8458 = 8458,
            /// <summary>
            /// ---- - 
            /// </summary>
            Ultimate_Augite = 8459,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8460 = 8460,
            /// <summary>
            /// Touch n' Go - 
            /// </summary>
            Wing_Ring = 8461,
            /// <summary>
            /// Gun Boost - 
            /// </summary>
            Engraved_Dog_Tag = 8462,
            /// <summary>
            /// ---- - 
            /// </summary>
            Red_Ribbon = 8463,
            /// <summary>
            /// Agi - Cost 4 SP
            /// </summary>
            Ember_Ring = 8464,
            /// <summary>
            /// Agilao - Cost 8 SP
            /// </summary>
            Flame_Ring = 8465,
            /// <summary>
            /// Agidyne - Cost 12 SP
            /// </summary>
            Inferno_Ring = 8466,
            /// <summary>
            /// Maragi - Cost 10 SP
            /// </summary>
            Spiral_Ember_Ring = 8467,
            /// <summary>
            /// Maragion - Cost 16 SP
            /// </summary>
            Spiral_Flame_Ring = 8468,
            /// <summary>
            /// Maragidyne - Cost 22 SP
            /// </summary>
            Spiral_Inferno_Ring = 8469,
            /// <summary>
            /// Bufu - Cost 4 SP
            /// </summary>
            Frost_Ring = 8470,
            /// <summary>
            /// Bufula - Cost 8 SP
            /// </summary>
            Snow_Ring = 8471,
            /// <summary>
            /// Bufudyne - Cost 12 SP
            /// </summary>
            Blizzard_Ring = 8472,
            /// <summary>
            /// Mabufu - Cost 10 SP
            /// </summary>
            Spiral_Frost_Ring = 8473,
            /// <summary>
            /// Mabufula - Cost 16 SP
            /// </summary>
            Spiral_Snow_Ring = 8474,
            /// <summary>
            /// Mabufudyne - Cost 22 SP
            /// </summary>
            Spiral_Blizzard_Ring = 8475,
            /// <summary>
            /// Garu - Cost 3 SP
            /// </summary>
            Breeze_Ring = 8476,
            /// <summary>
            /// Garula - Cost 6 SP
            /// </summary>
            Wind_Ring = 8477,
            /// <summary>
            /// Garudyne - Cost 10 SP
            /// </summary>
            Gale_Ring = 8478,
            /// <summary>
            /// Magaru - Cost 8 SP
            /// </summary>
            Spiral_Breeze_Ring = 8479,
            /// <summary>
            /// Magarula - Cost 14 SP
            /// </summary>
            Spiral_Wind_Ring = 8480,
            /// <summary>
            /// Magarudyne - Cost 20 SP
            /// </summary>
            Spiral_Gale_Ring = 8481,
            /// <summary>
            /// Zio - Cost 4 SP
            /// </summary>
            Static_Ring = 8482,
            /// <summary>
            /// Zionga - Cost 8 SP
            /// </summary>
            Spark_Ring = 8483,
            /// <summary>
            /// Ziodyne - Cost 12 SP
            /// </summary>
            Thunder_Ring = 8484,
            /// <summary>
            /// Mazio - Cost 10 SP
            /// </summary>
            Spiral_Static_Ring = 8485,
            /// <summary>
            /// Mazionga - Cost 16 SP
            /// </summary>
            Spiral_Spark_Ring = 8486,
            /// <summary>
            /// Maziodyne - Cost 22 SP
            /// </summary>
            Spiral_Thunder_Ring = 8487,
            /// <summary>
            /// Hama - Cost 6 SP
            /// </summary>
            Holy_Ring = 8488,
            /// <summary>
            /// Hamaon - Cost 12 SP
            /// </summary>
            Hallowed_Ring = 8489,
            /// <summary>
            /// Mahama - Cost 14 SP
            /// </summary>
            Spiral_Holy_Ring = 8490,
            /// <summary>
            /// Mahamaon - Cost 26 SP
            /// </summary>
            Spiral_Hallowed_Ring = 8491,
            /// <summary>
            /// Kouha - Cost 4 SP
            /// </summary>
            Prayer_Ring = 8492,
            /// <summary>
            /// Kouga - Cost 8 SP
            /// </summary>
            Blessing_Ring = 8493,
            /// <summary>
            /// Kougaon - Cost 12 SP
            /// </summary>
            Divine_Ring = 8494,
            /// <summary>
            /// Makouha - Cost 10 SP
            /// </summary>
            Spiral_Prayer_Ring = 8495,
            /// <summary>
            /// Makouga - Cost 16 SP
            /// </summary>
            Spiral_Blessing_Ring = 8496,
            /// <summary>
            /// Makougaon - Cost 22 SP
            /// </summary>
            Spiral_Divine_Ring = 8497,
            /// <summary>
            /// Mudo - Cost 6 SP
            /// </summary>
            Death_Ring = 8498,
            /// <summary>
            /// Mudoon - Cost 12 SP
            /// </summary>
            Hell_Ring = 8499,
            /// <summary>
            /// Mamudo - Cost 14 SP
            /// </summary>
            Spiral_Death_Ring = 8500,
            /// <summary>
            /// Mamudoon - Cost 26 SP
            /// </summary>
            Spiral_Hell_Ring = 8501,
            /// <summary>
            /// Eiha - Cost 4 SP
            /// </summary>
            Grudge_Ring = 8502,
            /// <summary>
            /// Eiga - Cost 8 SP
            /// </summary>
            Curse_Ring = 8503,
            /// <summary>
            /// Eigaon - Cost 12 SP
            /// </summary>
            Hex_Ring = 8504,
            /// <summary>
            /// Maeiha - Cost 10 SP
            /// </summary>
            Spiral_Grudge_Ring = 8505,
            /// <summary>
            /// Maeiga - Cost 16 SP
            /// </summary>
            Spiral_Curse_Ring = 8506,
            /// <summary>
            /// Maeigaon - Cost 22 SP
            /// </summary>
            Spiral_Hex_Ring = 8507,
            /// <summary>
            /// Megido - Cost 15 SP
            /// </summary>
            Mighty_Ring = 8508,
            /// <summary>
            /// Megidola - Cost 24 SP
            /// </summary>
            Almighty_Ring = 8509,
            /// <summary>
            /// Megidolaon - Cost 38 SP
            /// </summary>
            Supreme_Ring = 8510,
            /// <summary>
            /// Frei - Cost 4 SP
            /// </summary>
            Atom_Ring = 8511,
            /// <summary>
            /// Freila - Cost 8 SP
            /// </summary>
            Nuclear_Ring = 8512,
            /// <summary>
            /// Freidyne - Cost 12 SP
            /// </summary>
            Reactor_Ring = 8513,
            /// <summary>
            /// Mafrei - Cost 10 SP
            /// </summary>
            Spiral_Atom_Ring = 8514,
            /// <summary>
            /// Mafreila - Cost 16 SP
            /// </summary>
            Spiral_Nuclear_Ring = 8515,
            /// <summary>
            /// Mafreidyne - Cost 22 SP
            /// </summary>
            Spiral_Reactor_Ring = 8516,
            /// <summary>
            /// Dazzler - Cost 3 SP
            /// </summary>
            Dizzy_Bangle = 8517,
            /// <summary>
            /// Nocturnal Flash - Cost 8 SP
            /// </summary>
            Spiral_Dizzy_Bangle = 8518,
            /// <summary>
            /// Pulinpa - Cost 3 SP
            /// </summary>
            Addle_Bangle = 8519,
            /// <summary>
            /// Tentarafoo - Cost 8 SP
            /// </summary>
            Spiral_Addle_Bangle = 8520,
            /// <summary>
            /// Evil Touch - Cost 3 SP
            /// </summary>
            Fear_Bangle = 8521,
            /// <summary>
            /// Evil Smile - Cost 8 SP
            /// </summary>
            Retail_Smile_Mask = 8522,
            /// <summary>
            /// Makajama - Cost 3 SP
            /// </summary>
            Forget_Bangle = 8523,
            /// <summary>
            /// Makajamaon - Cost 8 SP
            /// </summary>
            Spiral_Forget_Bangle = 8524,
            /// <summary>
            /// Dormina - Cost 3 SP
            /// </summary>
            Sleep_Bangle = 8525,
            /// <summary>
            /// Lullaby - Cost 8 SP
            /// </summary>
            Spiral_Sleep_Bangle = 8526,
            /// <summary>
            /// Taunt - Cost 3 SP
            /// </summary>
            Rage_Bangle = 8527,
            /// <summary>
            /// Wage War - Cost 8 SP
            /// </summary>
            Spiral_Rage_Bangle = 8528,
            /// <summary>
            /// Ominous Words - Cost 3 SP
            /// </summary>
            Gloom_Bangle = 8529,
            /// <summary>
            /// Abysmal Surge - Cost 8 SP
            /// </summary>
            Spiral_Gloom_Bangle = 8530,
            /// <summary>
            /// Marin Karin - Cost 3 SP
            /// </summary>
            Brainwash_Bangle = 8531,
            /// <summary>
            /// Brain Jack - Cost 8 SP
            /// </summary>
            Agitation_Crown = 8532,
            /// <summary>
            /// Life Drain - Cost 3 SP
            /// </summary>
            Life_Sapping_Mask = 8533,
            /// <summary>
            /// Spirit Drain - Cost 3 SP
            /// </summary>
            Spirit_Sapping_Mask = 8534,
            /// <summary>
            /// Foul Breath - Cost 8 SP
            /// </summary>
            Spirit_Sense_Mirror = 8535,
            /// <summary>
            /// Stagnant Air - Cost 5 SP
            /// </summary>
            Dark_Spirit_Mirror = 8536,
            /// <summary>
            /// Ghastly Wail - Cost 28 SP
            /// </summary>
            Spirit_Camera = 8537,
            /// <summary>
            /// Inferno - Cost 48 SP
            /// </summary>
            Dark_Flame_Band = 8538,
            /// <summary>
            /// Blazing Hell - Cost 54 SP
            /// </summary>
            Ardhanari_Band = 8539,
            /// <summary>
            /// Diamond Dust - Cost 48 SP
            /// </summary>
            Diamond_Dust_Lily = 8540,
            /// <summary>
            /// Ice Age - Cost 54 SP
            /// </summary>
            Frozen_Crown = 8541,
            /// <summary>
            /// Panta Rhei - Cost 42 Sp
            /// </summary>
            Storm_Sculpture = 8542,
            /// <summary>
            /// Vacuum Wave - Cost 48 SP
            /// </summary>
            Vacuum_Crown = 8543,
            /// <summary>
            /// Thunder Reign - Cost 48 SP
            /// </summary>
            Goddess_Horn = 8544,
            /// <summary>
            /// Wild Thunder - Cost 54 SP
            /// </summary>
            Thunder_Charm = 8545,
            /// <summary>
            /// Divine Judgement - Cost 38 SP
            /// </summary>
            Judgement_Cross = 8546,
            /// <summary>
            /// Samsara - Cost 40SP
            /// </summary>
            Spinning_Crown = 8547,
            /// <summary>
            /// Demonic Decree - Cost 38 SP
            /// </summary>
            Cursed_Ribbon = 8548,
            /// <summary>
            /// Die For Me! - Cost 40SP
            /// </summary>
            Crown_of_Death = 8549,
            /// <summary>
            /// Atomic Flare - Cost 48 SP
            /// </summary>
            Fire_Dragon_Horn = 8550,
            /// <summary>
            /// Cosmic Flare - Cost 54 SP
            /// </summary>
            Atomic_Crown = 8551,
            /// <summary>
            /// Black Viper - Cost 48 SP
            /// </summary>
            Black_Viper_Crown = 8552,
            /// <summary>
            /// Morning Star - Cost 55 SP
            /// </summary>
            Astral_Crown = 8553,
            /// <summary>
            /// Psi - Cost 4 SP
            /// </summary>
            Psy_Ring = 8554,
            /// <summary>
            /// Psio - Cost 8 SP
            /// </summary>
            Karma_Ring = 8555,
            /// <summary>
            /// Psiodyne - Cost 12 SP
            /// </summary>
            Mystic_Ring = 8556,
            /// <summary>
            /// Mapsi - Cost 10 SP
            /// </summary>
            Spiral_Psy_Ring = 8557,
            /// <summary>
            /// Mapsio - Cost 16 SP
            /// </summary>
            Spiral_Karma_Ring = 8558,
            /// <summary>
            /// Mapsiodyne - Cost 22 SP
            /// </summary>
            Spiral_Mystic_Ring = 8559,
            /// <summary>
            /// ---- - 
            /// </summary>
            BLANK_8560 = 8560,
            /// <summary>
            /// Psycho Force - Cost 48 SP
            /// </summary>
            Dragons_Heart = 8561,
            /// <summary>
            /// Psycho Blast - Cost 54 SP
            /// </summary>
            Psycho_Blast_Crown = 8562,
            /// <summary>
            /// Lunge - Cost 50 HP
            /// </summary>
            Lunge_Belt = 8563,
            /// <summary>
            /// Assault Drive - Cost 130 HP
            /// </summary>
            Assault_Belt = 8564,
            /// <summary>
            /// Megaton Raid - Cost 160 HP
            /// </summary>
            Megaton_Belt = 8565,
            /// <summary>
            /// God's Hand - Cost 250 HP
            /// </summary>
            Gods_Hand_Belt = 8566,
            /// <summary>
            /// Lucky Punch - Cost 30 HP
            /// </summary>
            Lucky_Belt = 8567,
            /// <summary>
            /// Miracle Punch - Cost 80 HP
            /// </summary>
            Miracle_Belt = 8568,
            /// <summary>
            /// Kill Rush - Cost 140 HP
            /// </summary>
            Rush_Belt = 8569,
            /// <summary>
            /// Gatling Blow - Cost 160 HP
            /// </summary>
            Gatling_Belt = 8570,
            /// <summary>
            /// Cleave - Cost 60 HP
            /// </summary>
            Cleave_Belt = 8571,
            /// <summary>
            /// Giant Slice - Cost 90 HP
            /// </summary>
            Giant_Slice_Belt = 8572,
            /// <summary>
            /// Brave Blade - Cost 240 HP
            /// </summary>
            Brave_Belt = 8573,
            /// <summary>
            /// Sword Dance - Cost 210 HP
            /// </summary>
            Sword_Dance_Belt = 8574,
            /// <summary>
            /// Hassou Tobi - Cost 250 HP
            /// </summary>
            Hassou_Tobi_Belt = 8575,
            /// <summary>
            /// Ayamur - Cost 250 HP
            /// </summary>
            Ayamur_Belt = 8576,
            /// <summary>
            /// Cornered Fang - Cost 100 HP
            /// </summary>
            Cornered_Belt = 8577,
            /// <summary>
            /// Rising Slash - Cost 140 HP
            /// </summary>
            Rising_Slash_Belt = 8578,
            /// <summary>
            /// Deadly Fury - Cost 180 HP
            /// </summary>
            Deadly_Fury_Belt = 8579,
            /// <summary>
            /// Snap - Cost 90 HP
            /// </summary>
            Snap_Belt = 8580,
            /// <summary>
            /// Triple Down - Cost 160 HP
            /// </summary>
            Triple_Shot_Belt = 8581,
            /// <summary>
            /// Oneshot Kill - Cost 170 HP
            /// </summary>
            Special_Shot_Belt = 8582,
            /// <summary>
            /// Riot Gun - Cost 240 HP
            /// </summary>
            Magic_Bullet_Belt = 8583,
            /// <summary>
            /// Double Shot - Cost 120 HP
            /// </summary>
            Double_Shot_Belt = 8584,
            /// <summary>
            /// Vajra Blast - Cost 130 HP
            /// </summary>
            Vajra_Blast_Belt = 8585,
            /// <summary>
            /// Vorpal Blade - Cost 230 HP
            /// </summary>
            Vorpal_Blade_Belt = 8586,
            /// <summary>
            /// Vicious Strike - Cost 180 HP
            /// </summary>
            Vicious_Strike_Belt = 8587,
            /// <summary>
            /// Heat Wave - Cost 200 HP
            /// </summary>
            Heat_Wave_Belt = 8588,
            /// <summary>
            /// Gigantomachia - Cost 250 HP
            /// </summary>
            Gigantomachia_Belt = 8589,
            /// <summary>
            /// Rampage - Cost 130 HP
            /// </summary>
            Brawler_Belt = 8590,
            /// <summary>
            /// Swift Strike - Cost 170 HP
            /// </summary>
            Swift_Strike_Belt = 8591,
            /// <summary>
            /// Deathbound - Cost 220 HP
            /// </summary>
            Deathbound_Belt = 8592,
            /// <summary>
            /// Agneyastra - Cost 240 HP
            /// </summary>
            Agneyastra_Belt = 8593,
            /// <summary>
            /// Double Fangs - Cost 100 HP
            /// </summary>
            Double_Fangs_Belt = 8594,
            /// <summary>
            /// Power Slash - Cost 100 HP
            /// </summary>
            Power_Slash_Belt = 8595,
            /// <summary>
            /// Tempest Slash - Cost 170 HP
            /// </summary>
            Tempest_Slash_Belt = 8596,
            /// <summary>
            /// Myriad Slashes - Cost 200 HP
            /// </summary>
            Myriad_Slash_Belt = 8597,
            /// <summary>
            /// Sledgehammer - Cost 100 HP
            /// </summary>
            Sledgehammer_Belt = 8598,
            /// <summary>
            /// Skull Cracker - Cost 100 HP
            /// </summary>
            Skull_Cracker_Belt = 8599,
            /// <summary>
            /// Terror Claw - Cost 80 HP
            /// </summary>
            Terror_Claw_Belt = 8600,
            /// <summary>
            /// Headbutt - Cost 90 HP
            /// </summary>
            Headbutt_Belt = 8601,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8602 = 8602,
            /// <summary>
            /// Dream Needle - Cost 80 HP
            /// </summary>
            Dream_Needle_Belt = 8603,
            /// <summary>
            /// Hysterical Slap - Cost 90 HP
            /// </summary>
            Hysterical_Slap_Belt = 8604,
            /// <summary>
            /// Negative Pile - Cost 120 HP
            /// </summary>
            Negative_Pile_Belt = 8605,
            /// <summary>
            /// Brain Shake - Cost 90 HP
            /// </summary>
            Brain_Shaker_Belt = 8606,
            /// <summary>
            /// Flash Bomb - Cost 190 HP
            /// </summary>
            Flash_Bomb_Belt = 8607,
            /// <summary>
            /// Mind Slice - Cost 190 HP
            /// </summary>
            Mind_Slice_Belt = 8608,
            /// <summary>
            /// Bloodbath - Cost 220 HP
            /// </summary>
            Bloodbath_Belt = 8609,
            /// <summary>
            /// Memory Belt - Cost 150 HP
            /// </summary>
            Memory_Blow_Belt = 8610,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_8611 = 8611,
            /// <summary>
            /// Dormin Rush - Cost 160 HP
            /// </summary>
            Dormin_Rush_Belt = 8612,
            /// <summary>
            /// OniKagura - Cost 160 HP
            /// </summary>
            OniKagura_Belt = 8613,
            /// <summary>
            /// Bad Beat - Cost 210 HP
            /// </summary>
            Bad_Beat_Belt = 8614,
            /// <summary>
            /// Brain Buster - Cost 220 HP
            /// </summary>
            Brain_Buster_Belt = 8615,
            /// <summary>
            /// Dia - Cost 3 SP
            /// </summary>
            Aid_Charm = 8616,
            /// <summary>
            /// Diarama - Cost 6 SP
            /// </summary>
            Cure_Charm = 8617,
            /// <summary>
            /// Diarahan - Cost 18 SP
            /// </summary>
            Heal_Charm = 8618,
            /// <summary>
            /// Media - Cost 7 SP
            /// </summary>
            Spiral_Aid_Charm = 8619,
            /// <summary>
            /// Mediarama - Cost 12 SP
            /// </summary>
            Spiral_Cure_Charm = 8620,
            /// <summary>
            /// Mediarahan - Cost 30 SP
            /// </summary>
            Spiral_Heal_Charm = 8621,
            /// <summary>
            /// Recarm - Cost 8 SP
            /// </summary>
            Revival_Charm = 8622,
            /// <summary>
            /// Samarecarm - Cost 18 SP
            /// </summary>
            Rejuvenate_Charm = 8623,
            /// <summary>
            /// Holy Benevolence - Cost 27 SP
            /// </summary>
            Rosary_of_Purity = 8624,
            /// <summary>
            /// Amrita Drop - Cost 6 SP
            /// </summary>
            Amrita_Charm = 8625,
            /// <summary>
            /// Amrita Shower - Cost 12 SP
            /// </summary>
            Spiral_Amrita_Charm = 8626,
            /// <summary>
            /// Salvation - Cost 48 SP
            /// </summary>
            Salvation_Crown = 8627,
            /// <summary>
            /// Taunting Aura - Cost 4 SP
            /// </summary>
            Alluring_Belt = 8628,
            /// <summary>
            /// Concealment - Cost 4 SP
            /// </summary>
            Hidden_Ring = 8629,
            /// <summary>
            /// Patra - Cost 4 SP
            /// </summary>
            Alarm_Charm = 8630,
            /// <summary>
            /// Energy Shower - Cost 8 SP
            /// </summary>
            Spiral_Energy_Charm = 8631,
            /// <summary>
            /// Energy Drop - Cost 4 SP
            /// </summary>
            Energy_Charm = 8632,
            /// <summary>
            /// Baisudi - Cost 4 SP
            /// </summary>
            Baisudi_Charm = 8633,
            /// <summary>
            /// Me Patra - Cost 8 SP
            /// </summary>
            Spiral_Alarm_Charm = 8634,
            /// <summary>
            /// Mabaisudi - Cost 8 SP
            /// </summary>
            Spiral_Baisudi_Charm = 8635,
            /// <summary>
            /// Tarukaja - Cost 8 SP
            /// </summary>
            Rasetsu_Anklet = 8636,
            /// <summary>
            /// Rakukaja - Cost 8 SP
            /// </summary>
            Vajra_Anklet = 8637,
            /// <summary>
            /// Sakukaja - Cost 8 SP
            /// </summary>
            Cat_Brooch = 8638,
            /// <summary>
            /// Heat Riser - Cost 30 SP
            /// </summary>
            Heat_Riser_Anklet = 8639,
            /// <summary>
            /// Matarukaja - Cost 24 SP
            /// </summary>
            Spiral_Rastsu_Anklet = 8640,
            /// <summary>
            /// Marakukaja - Cost 24 SP
            /// </summary>
            Spiral_Vajra_Anklet = 8641,
            /// <summary>
            /// Masukukaja - Cost 24 SP
            /// </summary>
            Spiral_Idaten_Anklet = 8642,
            /// <summary>
            /// Thermoplyae - Cost 30 SP
            /// </summary>
            Savior_Brooch = 8643,
            /// <summary>
            /// Tarunda - Cost 8 SP
            /// </summary>
            Weak_Anklet = 8644,
            /// <summary>
            /// Rakunda - Cost 8 SP
            /// </summary>
            Feeble_Anklet = 8645,
            /// <summary>
            /// Sukunda - Cost 8 SP
            /// </summary>
            Stalling_Anklet = 8646,
            /// <summary>
            /// Debilitate - Cost 30 SP
            /// </summary>
            Debilitate_Anklet = 8647,
            /// <summary>
            /// Matarunda - Cost 24 SP
            /// </summary>
            Spiral_Weak_Anklet = 8648,
            /// <summary>
            /// Marakunda - Cost 24 SP
            /// </summary>
            Spiral_Feeble_Anklet = 8649,
            /// <summary>
            /// Masukunda - Cost 24 SP
            /// </summary>
            Spiral_Stalling_Anklet = 8650,
            /// <summary>
            /// Dekunda - Cost 10 SP
            /// </summary>
            Dekunda_Anklet = 8651,
            /// <summary>
            /// Dekaja - Cost 10 SP
            /// </summary>
            Calming_Anklet = 8652,
            /// <summary>
            /// Charge - Cost 15 SP
            /// </summary>
            Empowering_Anklet = 8653,
            /// <summary>
            /// Concentrate - Cost 15 SP
            /// </summary>
            Concentration_Anklet = 8654,
            /// <summary>
            /// Rebellion - Cost 5 SP
            /// </summary>
            Rebellion_Anklet = 8655,
            /// <summary>
            /// Revolution - Cost 5 SP
            /// </summary>
            Revolution_Anklet = 8656,
            /// <summary>
            /// Makarakarn - Cost 24 SP
            /// </summary>
            Magic_Mirror_Charm = 8657,
            /// <summary>
            /// Tetrakarn - Cost 24 SP
            /// </summary>
            Phys_Mirror_Charm = 8658,
            /// <summary>
            /// Tetraja - Cost 24 SP
            /// </summary>
            Immortal_Charm = 8659,
            /// <summary>
            /// Tetra Break - Cost 9 SP
            /// </summary>
            Wall_Break_Charm = 8660,
            /// <summary>
            /// Makara Break - Cost 9 SP
            /// </summary>
            Barrier_Break_Charm = 8661,
            /// <summary>
            /// Fire Wall - Cost 18 SP
            /// </summary>
            AntiFire_Choker = 8662,
            /// <summary>
            /// Ice Wall - Cost 18 SP
            /// </summary>
            AntiIce_Choker = 8663,
            /// <summary>
            /// Elec Wall - Cost 18 SP
            /// </summary>
            AntiElec_Choker = 8664,
            /// <summary>
            /// Wind Wall - Cost 18 SP
            /// </summary>
            AntiWind_Choker = 8665,
            /// <summary>
            /// Fire Break - Cost 6 SP
            /// </summary>
            Fire_Breaker_Bell = 8666,
            /// <summary>
            /// Ice Break - Cost 6 SP
            /// </summary>
            Ice_Breaker_Bell = 8667,
            /// <summary>
            /// Wind Break - Cost 6 SP
            /// </summary>
            Wind_Breaker_Bell = 8668,
            /// <summary>
            /// Elec Break - Cost 6 SP
            /// </summary>
            Elec_Breaker_Bell = 8669,
            /// <summary>
            /// Nuke Wall - Cost 18 SP
            /// </summary>
            AntiNuke_Choker = 8670,
            /// <summary>
            /// Psy Wall - Cost 18 SP
            /// </summary>
            AntiPsy_Choker = 8671,
            /// <summary>
            /// Nuke Break - Cost 6 SP
            /// </summary>
            Nuke_Breaker_Bell = 8672,
            /// <summary>
            /// Psy Break - Cost 6 SP
            /// </summary>
            Psy_Breaker_Bell = 8673,
            /// <summary>
            /// 
            /// </summary>
            _0x1E2 = 8674,
            /// <summary>
            /// Attack Master - St+5
            /// </summary>
            Regent_R = 8675,
            /// <summary>
            /// Mana Bonus - All stats+2
            /// </summary>
            Queens_Necklace_R = 8676,
            /// <summary>
            /// Dodge Phys - En+5
            /// </summary>
            Stone_of_Scone_R = 8677,
            /// <summary>
            /// Bless Amp - All stats+3
            /// </summary>
            KohiNoor_R = 8678,
            /// <summary>
            /// High Counter - En+5
            /// </summary>
            Orlov_R = 8679,
            /// <summary>
            /// AutoMataru - En+8
            /// </summary>
            Emperors_Charm_R = 8680,
            /// <summary>
            /// Regenerate 3 - All stats+4
            /// </summary>
            Hope_Diamond_R = 8681,
            /// <summary>
            /// Angelic Grace - All stats+6
            /// </summary>
            Crystal_Skull_R = 8682,
            /// <summary>
            /// Evade Phys - All stats+6
            /// </summary>
            Orichalcum = 8683,
            /// <summary>
            /// Evade Phys - All stats+7
            /// </summary>
            Orichalcum_R = 8684,
            /// <summary>
            /// Lucky Punch - Cost 30 HP
            /// </summary>
            Gamblers_Ring = 8685,
            /// <summary>
            /// Dazzler - Cost 3 SP
            /// </summary>
            Dazzling_Necklace = 8686,
            /// <summary>
            /// Frei - Cost 4 SP
            /// </summary>
            Nuke_Brooch = 8687,
            /// <summary>
            /// Soul Touch - 
            /// </summary>
            Starlight_Glove = 8688,
            /// <summary>
            /// Mana Rise - 
            /// </summary>
            Moonlight_Phones = 8689,
            /// <summary>
            /// Life Rise - 
            /// </summary>
            Wardens_Baton = 8690,
            /// <summary>
            /// Last Stand - 
            /// </summary>
            Feather_Cape = 8691,
            /// <summary>
            /// Gun Amp - 
            /// </summary>
            Demonica_Device = 8692,
            /// <summary>
            /// Heat Up - 
            /// </summary>
            Camera_Strap = 8693,
            /// <summary>
            /// Mana Bonus - 
            /// </summary>
            Unused_Item = 8694,
            /// <summary>
            /// 
            /// </summary>
            _0x1F7 = 8695,
            /// <summary>
            /// 
            /// </summary>
            _0x1F8 = 8696,
            /// <summary>
            /// 
            /// </summary>
            _0x1F9 = 8697,
            /// <summary>
            /// 
            /// </summary>
            _0x1FA = 8698,
            /// <summary>
            /// 
            /// </summary>
            _0x1FB = 8699,
            /// <summary>
            /// 
            /// </summary>
            _0x1FC = 8700,
            /// <summary>
            /// 
            /// </summary>
            _0x1FD = 8701,
            /// <summary>
            /// 
            /// </summary>
            _0x1FE = 8702,
            /// <summary>
            /// 
            /// </summary>
            _0x1FF = 8703,
            /// <summary>
            /// 
            /// </summary>
            BLANK_12288 = 12288,
            /// <summary>
            /// 
            /// </summary>
            Devil_Fruit = 12289,
            /// <summary>
            /// 
            /// </summary>
            Recov_R__50_mg = 12290,
            /// <summary>
            /// 
            /// </summary>
            Recov_R__100_mg = 12291,
            /// <summary>
            /// 
            /// </summary>
            Takemedic = 12292,
            /// <summary>
            /// 
            /// </summary>
            Lifestone = 12293,
            /// <summary>
            /// 
            /// </summary>
            Bead = 12294,
            /// <summary>
            /// 
            /// </summary>
            Takemedic_All = 12295,
            /// <summary>
            /// 
            /// </summary>
            Takemedic_All_V = 12296,
            /// <summary>
            /// 
            /// </summary>
            Takemedic_All_Z = 12297,
            /// <summary>
            /// 
            /// </summary>
            Bead_Chain = 12298,
            /// <summary>
            /// 
            /// </summary>
            Soul_Drop = 12299,
            /// <summary>
            /// 
            /// </summary>
            Snuff_Soul = 12300,
            /// <summary>
            /// 
            /// </summary>
            Chewing_Soul = 12301,
            /// <summary>
            /// 
            /// </summary>
            Soul_Food = 12302,
            /// <summary>
            /// 
            /// </summary>
            Revival_Bead = 12303,
            /// <summary>
            /// 
            /// </summary>
            Balm_of_Life = 12304,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12305 = 12305,
            /// <summary>
            /// 
            /// </summary>
            Nohar_M = 12306,
            /// <summary>
            /// 
            /// </summary>
            Relax_Gel = 12307,
            /// <summary>
            /// 
            /// </summary>
            Alert_Capsule = 12308,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12309 = 12309,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12310 = 12310,
            /// <summary>
            /// 
            /// </summary>
            Vanish_Ball = 12311,
            /// <summary>
            /// 
            /// </summary>
            Soma = 12312,
            /// <summary>
            /// 
            /// </summary>
            Amrita_Soda = 12313,
            /// <summary>
            /// 
            /// </summary>
            Hiranya = 12314,
            /// <summary>
            /// 
            /// </summary>
            Muscle_Drink = 12315,
            /// <summary>
            /// 
            /// </summary>
            Odd_Morsel = 12316,
            /// <summary>
            /// 
            /// </summary>
            Rancid_Gravy = 12317,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12318 = 12318,
            /// <summary>
            /// 
            /// </summary>
            Magic_Ointment = 12319,
            /// <summary>
            /// 
            /// </summary>
            Physical_Ointment = 12320,
            /// <summary>
            /// 
            /// </summary>
            Rasetsu_Ofuda = 12321,
            /// <summary>
            /// 
            /// </summary>
            Idaten_Ofuda = 12322,
            /// <summary>
            /// 
            /// </summary>
            Kongou_Ofuda = 12323,
            /// <summary>
            /// 
            /// </summary>
            Kajaclear_R = 12324,
            /// <summary>
            /// 
            /// </summary>
            Kundaclear_R = 12325,
            /// <summary>
            /// 
            /// </summary>
            Molotov_Cocktail = 12326,
            /// <summary>
            /// 
            /// </summary>
            Blowtorch = 12327,
            /// <summary>
            /// 
            /// </summary>
            Freeze_Spray = 12328,
            /// <summary>
            /// 
            /// </summary>
            Dry_Ice = 12329,
            /// <summary>
            /// 
            /// </summary>
            Air_Cannon = 12330,
            /// <summary>
            /// 
            /// </summary>
            Vacuum_Cutter = 12331,
            /// <summary>
            /// 
            /// </summary>
            Stun_Gun = 12332,
            /// <summary>
            /// 
            /// </summary>
            Magneto_Coil = 12333,
            /// <summary>
            /// 
            /// </summary>
            Megido_Bomb = 12334,
            /// <summary>
            /// 
            /// </summary>
            Sacramental_Bread = 12335,
            /// <summary>
            /// 
            /// </summary>
            Straw_Doll = 12336,
            /// <summary>
            /// 
            /// </summary>
            Hell_Magatama = 12337,
            /// <summary>
            /// 
            /// </summary>
            Cyclone_Magatama = 12338,
            /// <summary>
            /// 
            /// </summary>
            Frost_Magatama = 12339,
            /// <summary>
            /// 
            /// </summary>
            Arc_Magatama = 12340,
            /// <summary>
            /// 
            /// </summary>
            Psycho_Bomb = 12341,
            /// <summary>
            /// 
            /// </summary>
            Psy_Wheel = 12342,
            /// <summary>
            /// 
            /// </summary>
            Atom_Match = 12343,
            /// <summary>
            /// 
            /// </summary>
            Nuke_Cracker = 12344,
            /// <summary>
            /// 
            /// </summary>
            Happy_Bomb = 12345,
            /// <summary>
            /// 
            /// </summary>
            Segaki_Rice = 12346,
            /// <summary>
            /// 
            /// </summary>
            Curse_Bomb = 12347,
            /// <summary>
            /// 
            /// </summary>
            Five_Inch_Nail = 12348,
            /// <summary>
            /// 
            /// </summary>
            Revivadrin = 12349,
            /// <summary>
            /// 
            /// </summary>
            Medicine = 12350,
            /// <summary>
            /// 
            /// </summary>
            Life_Ointment = 12351,
            /// <summary>
            /// 
            /// </summary>
            Homunculus = 12352,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12353 = 12353,
            /// <summary>
            /// 
            /// </summary>
            Reviv_All = 12354,
            /// <summary>
            /// 
            /// </summary>
            Renew_All = 12355,
            /// <summary>
            /// 
            /// </summary>
            Recover_Oil = 12356,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12357 = 12357,
            /// <summary>
            /// 
            /// </summary>
            DVD_Player = 12358,
            /// <summary>
            /// 
            /// </summary>
            Garden_Energy = 12359,
            /// <summary>
            /// 
            /// </summary>
            Bio_Nutrients = 12360,
            /// <summary>
            /// 
            /// </summary>
            Mega_Fertilizer = 12361,
            /// <summary>
            /// 
            /// </summary>
            Godly_Magatama = 12362,
            /// <summary>
            /// 
            /// </summary>
            Blast_Magatama = 12363,
            /// <summary>
            /// 
            /// </summary>
            Holy_Magatama = 12364,
            /// <summary>
            /// 
            /// </summary>
            Grudge_Magatama = 12365,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12366 = 12366,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12367 = 12367,
            /// <summary>
            /// 
            /// </summary>
            PC_Tool_Set = 12368,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12369 = 12369,
            /// <summary>
            /// 
            /// </summary>
            Glass_Vase = 12370,
            /// <summary>
            /// 
            /// </summary>
            Star_Mirror = 12371,
            /// <summary>
            /// 
            /// </summary>
            Snack_Pack = 12372,
            /// <summary>
            /// 
            /// </summary>
            Musty_Pages = 12373,
            /// <summary>
            /// 
            /// </summary>
            Homemaker_Hero = 12374,
            /// <summary>
            /// 
            /// </summary>
            Heart_Ring = 12375,
            /// <summary>
            /// 
            /// </summary>
            Heart_Necklace = 12376,
            /// <summary>
            /// 
            /// </summary>
            Designer_Perfume = 12377,
            /// <summary>
            /// 
            /// </summary>
            Luxury_Aroma_Set = 12378,
            /// <summary>
            /// 
            /// </summary>
            Mini_Cactus = 12379,
            /// <summary>
            /// 
            /// </summary>
            Flower_Basket = 12380,
            /// <summary>
            /// 
            /// </summary>
            Bath_of_Roses = 12381,
            /// <summary>
            /// 
            /// </summary>
            Black_Mug = 12382,
            /// <summary>
            /// 
            /// </summary>
            Sakura_Fan = 12383,
            /// <summary>
            /// 
            /// </summary>
            Fountain_Pen = 12384,
            /// <summary>
            /// 
            /// </summary>
            Robot_Vacuum = 12385,
            /// <summary>
            /// 
            /// </summary>
            Motorbike_Figure = 12386,
            /// <summary>
            /// 
            /// </summary>
            Local_Mascot_Set = 12387,
            /// <summary>
            /// 
            /// </summary>
            Spotlight = 12388,
            /// <summary>
            /// 
            /// </summary>
            Goho_M = 12389,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12390 = 12390,
            /// <summary>
            /// 
            /// </summary>
            Smokescreen = 12391,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12392 = 12392,
            /// <summary>
            /// 
            /// </summary>
            Hypno_Mist = 12393,
            /// <summary>
            /// 
            /// </summary>
            Calming_Aroma = 12394,
            /// <summary>
            /// 
            /// </summary>
            Covertizer = 12395,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12396 = 12396,
            /// <summary>
            /// 
            /// </summary>
            Silk_Yarn = 12397,
            /// <summary>
            /// 
            /// </summary>
            Thick_Parchment = 12398,
            /// <summary>
            /// 
            /// </summary>
            Tin_Clasp = 12399,
            /// <summary>
            /// 
            /// </summary>
            Plant_Balm = 12400,
            /// <summary>
            /// 
            /// </summary>
            Cork_Bark = 12401,
            /// <summary>
            /// 
            /// </summary>
            Iron_Sand = 12402,
            /// <summary>
            /// 
            /// </summary>
            Condenser_Lens = 12403,
            /// <summary>
            /// 
            /// </summary>
            Aluminum_Sheet = 12404,
            /// <summary>
            /// 
            /// </summary>
            Tanned_Leather = 12405,
            /// <summary>
            /// 
            /// </summary>
            Red_Phosphorus = 12406,
            /// <summary>
            /// 
            /// </summary>
            Liquid_Mercury = 12407,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12408 = 12408,
            /// <summary>
            /// 
            /// </summary>
            Wise_Mens_Words = 12409,
            /// <summary>
            /// 
            /// </summary>
            Ghost_Encounters = 12410,
            /// <summary>
            /// 
            /// </summary>
            Tidying_the_Heart = 12411,
            /// <summary>
            /// 
            /// </summary>
            Buchikos_Story = 12412,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12413 = 12413,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12414 = 12414,
            /// <summary>
            /// 
            /// </summary>
            Punch_Ouch = 12415,
            /// <summary>
            /// 
            /// </summary>
            Starvicks = 12416,
            /// <summary>
            /// 
            /// </summary>
            Udagawa_Water = 12417,
            /// <summary>
            /// 
            /// </summary>
            CRT_Television = 12418,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12419 = 12419,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12420 = 12420,
            /// <summary>
            /// 
            /// </summary>
            Master_Swordsman = 12421,
            /// <summary>
            /// 
            /// </summary>
            Flowerpedia = 12422,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12423 = 12423,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12424 = 12424,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12425 = 12425,
            /// <summary>
            /// 
            /// </summary>
            Heroic_Revelations = 12426,
            /// <summary>
            /// 
            /// </summary>
            Call_me_Chief = 12427,
            /// <summary>
            /// 
            /// </summary>
            The_Art_of_Automata = 12428,
            /// <summary>
            /// 
            /// </summary>
            Reckless_Casanova = 12429,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12430 = 12430,
            /// <summary>
            /// 
            /// </summary>
            Rubbish = 12431,
            /// <summary>
            /// 
            /// </summary>
            Money_Distributer = 12432,
            /// <summary>
            /// 
            /// </summary>
            Item_Distributer = 12433,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12434 = 12434,
            /// <summary>
            /// 
            /// </summary>
            Jagariko = 12435,
            /// <summary>
            /// 
            /// </summary>
            Broken_Rock_Salt = 12436,
            /// <summary>
            /// 
            /// </summary>
            Movie_Ticket = 12437,
            /// <summary>
            /// 
            /// </summary>
            Movie_02_Ticket = 12438,
            /// <summary>
            /// 
            /// </summary>
            Movie_03_Ticket = 12439,
            /// <summary>
            /// 
            /// </summary>
            Movie_04_Ticket = 12440,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12441 = 12441,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12442 = 12442,
            /// <summary>
            /// 
            /// </summary>
            Summer_Lotto_S = 12443,
            /// <summary>
            /// 
            /// </summary>
            Autumn_Bread = 12444,
            /// <summary>
            /// 
            /// </summary>
            Element_Set = 12445,
            /// <summary>
            /// 
            /// </summary>
            Forces_Set = 12446,
            /// <summary>
            /// 
            /// </summary>
            Shitamachi_Reborn = 12447,
            /// <summary>
            /// 
            /// </summary>
            Star_Forneus = 12448,
            /// <summary>
            /// 
            /// </summary>
            Weekend_Parks = 12449,
            /// <summary>
            /// 
            /// </summary>
            Train_of_Life = 12450,
            /// <summary>
            /// 
            /// </summary>
            Power_Intuition = 12451,
            /// <summary>
            /// 
            /// </summary>
            Bonehead = 12452,
            /// <summary>
            /// 
            /// </summary>
            Crime_Lab_Squad = 12453,
            /// <summary>
            /// 
            /// </summary>
            Not_so_hot_Betsy = 12454,
            /// <summary>
            /// 
            /// </summary>
            Bubbly_Hills, _90210 = 12455,
            /// <summary>
            /// 
            /// </summary>
            ICU = 12456,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12457 = 12457,
            /// <summary>
            /// 
            /// </summary>
            Drizzled_Natto = 12458,
            /// <summary>
            /// 
            /// </summary>
            Squid_Tri_Pack = 12459,
            /// <summary>
            /// 
            /// </summary>
            Idol_Pins = 12460,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12461 = 12461,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12462 = 12462,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12463 = 12463,
            /// <summary>
            /// 
            /// </summary>
            Tokyo_Shrines = 12464,
            /// <summary>
            /// 
            /// </summary>
            Fishpond_Spotter = 12465,
            /// <summary>
            /// 
            /// </summary>
            Yoncha_Walker_04 = 12466,
            /// <summary>
            /// 
            /// </summary>
            Night_Skies = 12467,
            /// <summary>
            /// 
            /// </summary>
            Jack_Frost_Doll = 12468,
            /// <summary>
            /// 
            /// </summary>
            Burger_kun_Doll = 12469,
            /// <summary>
            /// 
            /// </summary>
            Wanna_kun_Doll = 12470,
            /// <summary>
            /// 
            /// </summary>
            Lexy_Doll = 12471,
            /// <summary>
            /// 
            /// </summary>
            Uji_Match_Flan = 12472,
            /// <summary>
            /// 
            /// </summary>
            Truffles = 12473,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12474 = 12474,
            /// <summary>
            /// 
            /// </summary>
            Limelight = 12475,
            /// <summary>
            /// 
            /// </summary>
            Amateur_Coffee = 12476,
            /// <summary>
            /// 
            /// </summary>
            Harsh_Coffee = 12477,
            /// <summary>
            /// 
            /// </summary>
            Baptismal_Water = 12478,
            /// <summary>
            /// 
            /// </summary>
            Exorcism_Water = 12479,
            /// <summary>
            /// 
            /// </summary>
            Wine_of_Grace = 12480,
            /// <summary>
            /// 
            /// </summary>
            Repentance_Ashes = 12481,
            /// <summary>
            /// 
            /// </summary>
            Dipped_Katsu_Sando = 12482,
            /// <summary>
            /// 
            /// </summary>
            Book_Cover = 12483,
            /// <summary>
            /// 
            /// </summary>
            Castella = 12484,
            /// <summary>
            /// 
            /// </summary>
            Crimson_Lipstick = 12485,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12486 = 12486,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12487 = 12487,
            /// <summary>
            /// 
            /// </summary>
            Tetra_Hammer = 12488,
            /// <summary>
            /// 
            /// </summary>
            Makara_Hammer = 12489,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12490 = 12490,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12491 = 12491,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12492 = 12492,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12493 = 12493,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12494 = 12494,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12495 = 12495,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12496 = 12496,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12497 = 12497,
            /// <summary>
            /// 
            /// </summary>
            Casual_Rod = 12498,
            /// <summary>
            /// 
            /// </summary>
            Powerful_Rod = 12499,
            /// <summary>
            /// 
            /// </summary>
            Miracle_Rod = 12500,
            /// <summary>
            /// 
            /// </summary>
            Arginade = 12501,
            /// <summary>
            /// 
            /// </summary>
            Dr_Salt_Neo = 12502,
            /// <summary>
            /// 
            /// </summary>
            Joylent = 12503,
            /// <summary>
            /// 
            /// </summary>
            MRE_Ration = 12504,
            /// <summary>
            /// 
            /// </summary>
            Oatmeal_Ration = 12505,
            /// <summary>
            /// 
            /// </summary>
            Torimeshi_Ration = 12506,
            /// <summary>
            /// 
            /// </summary>
            Fruit_Ration = 12507,
            /// <summary>
            /// 
            /// </summary>
            Seafood_Aojiru = 12508,
            /// <summary>
            /// 
            /// </summary>
            Beauty_Aojiru = 12509,
            /// <summary>
            /// 
            /// </summary>
            Vitality_Aojiru = 12510,
            /// <summary>
            /// 
            /// </summary>
            Nasty_Aojiru = 12511,
            /// <summary>
            /// 
            /// </summary>
            Onsen_Aojiru = 12512,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12513 = 12513,
            /// <summary>
            /// 
            /// </summary>
            Fulfiller = 12514,
            /// <summary>
            /// 
            /// </summary>
            Summer_Lotto_R = 12515,
            /// <summary>
            /// 
            /// </summary>
            Happy_Pop = 12516,
            /// <summary>
            /// 
            /// </summary>
            Thaw_Stone = 12517,
            /// <summary>
            /// 
            /// </summary>
            Douse_Orb = 12518,
            /// <summary>
            /// 
            /// </summary>
            Dischard_Crystal = 12519,
            /// <summary>
            /// 
            /// </summary>
            Second_Maid = 12520,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12521 = 12521,
            /// <summary>
            /// 
            /// </summary>
            Sandwich = 12522,
            /// <summary>
            /// 
            /// </summary>
            Fruit_Danish = 12523,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12524 = 12524,
            /// <summary>
            /// 
            /// </summary>
            Yakisoba_Pan = 12525,
            /// <summary>
            /// 
            /// </summary>
            Creature = 12526,
            /// <summary>
            /// 
            /// </summary>
            Earl_Green = 12527,
            /// <summary>
            /// 
            /// </summary>
            Raw_Punch = 12528,
            /// <summary>
            /// 
            /// </summary>
            Muscle_Tea = 12529,
            /// <summary>
            /// 
            /// </summary>
            Manta = 12530,
            /// <summary>
            /// 
            /// </summary>
            Nastea = 12531,
            /// <summary>
            /// 
            /// </summary>
            _1UP = 12532,
            /// <summary>
            /// 
            /// </summary>
            Gambla_Goemon = 12533,
            /// <summary>
            /// 
            /// </summary>
            Golfer_Sarutahiko = 12534,
            /// <summary>
            /// 
            /// </summary>
            Calling_Postcard = 12535,
            /// <summary>
            /// 
            /// </summary>
            Refresh_Aroma = 12536,
            /// <summary>
            /// 
            /// </summary>
            Protein = 12537,
            /// <summary>
            /// 
            /// </summary>
            Moist_Protein = 12538,
            /// <summary>
            /// 
            /// </summary>
            Fried_Bread = 12539,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12540 = 12540,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12541 = 12541,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12542 = 12542,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12543 = 12543,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12544 = 12544,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12545 = 12545,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12546 = 12546,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12547 = 12547,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12548 = 12548,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12549 = 12549,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12550 = 12550,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12551 = 12551,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12552 = 12552,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12553 = 12553,
            /// <summary>
            /// 
            /// </summary>
            Expert = 12554,
            /// <summary>
            /// 
            /// </summary>
            Insane = 12555,
            /// <summary>
            /// 
            /// </summary>
            Beginner = 12556,
            /// <summary>
            /// 
            /// </summary>
            Intermediate = 12557,
            /// <summary>
            /// 
            /// </summary>
            Advanced = 12558,
            /// <summary>
            /// 
            /// </summary>
            Surprise_Sando = 12559,
            /// <summary>
            /// 
            /// </summary>
            Nostalgic_Steak = 12560,
            /// <summary>
            /// 
            /// </summary>
            Frui_Tea = 12561,
            /// <summary>
            /// 
            /// </summary>
            Totem_Pole = 12562,
            /// <summary>
            /// 
            /// </summary>
            Relaxing_Coffee = 12563,
            /// <summary>
            /// 
            /// </summary>
            Oo_hot_Tea = 12564,
            /// <summary>
            /// 
            /// </summary>
            Love_pancake = 12565,
            /// <summary>
            /// 
            /// </summary>
            Sincere_Omelette = 12566,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12567 = 12567,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12568 = 12568,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12569 = 12569,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12570 = 12570,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12571 = 12571,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12572 = 12572,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12573 = 12573,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12574 = 12574,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12575 = 12575,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12576 = 12576,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12577 = 12577,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12578 = 12578,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12579 = 12579,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12580 = 12580,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12581 = 12581,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12582 = 12582,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12583 = 12583,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12584 = 12584,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12585 = 12585,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12586 = 12586,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12587 = 12587,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12588 = 12588,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12589 = 12589,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12590 = 12590,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12591 = 12591,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12592 = 12592,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12593 = 12593,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12594 = 12594,
            /// <summary>
            /// 
            /// </summary>
            Small_Boilie = 12595,
            /// <summary>
            /// 
            /// </summary>
            Medium_Boilie = 12596,
            /// <summary>
            /// 
            /// </summary>
            Large_Boilie = 12597,
            /// <summary>
            /// 
            /// </summary>
            Top_class_Boilie = 12598,
            /// <summary>
            /// 
            /// </summary>
            Guardian_Boilie = 12599,
            /// <summary>
            /// 
            /// </summary>
            Big_Bang_Burger = 12600,
            /// <summary>
            /// 
            /// </summary>
            Saturn_Fries = 12601,
            /// <summary>
            /// 
            /// </summary>
            Earth_Burger = 12602,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12603 = 12603,
            /// <summary>
            /// 
            /// </summary>
            Moon_Burger = 12604,
            /// <summary>
            /// 
            /// </summary>
            Supernova_Burger = 12605,
            /// <summary>
            /// 
            /// </summary>
            Karaage_King = 12606,
            /// <summary>
            /// 
            /// </summary>
            Spring_Fruit_Pack = 12607,
            /// <summary>
            /// 
            /// </summary>
            Foreign_Nikuman = 12608,
            /// <summary>
            /// 
            /// </summary>
            Phantom_Wafers = 12609,
            /// <summary>
            /// 
            /// </summary>
            Soothing_Soba = 12610,
            /// <summary>
            /// 
            /// </summary>
            Agodashi_Oden = 12611,
            /// <summary>
            /// 
            /// </summary>
            Party_in_a_Can = 12612,
            /// <summary>
            /// 
            /// </summary>
            Digital_Camera = 12613,
            /// <summary>
            /// 
            /// </summary>
            Face_Beautifier = 12614,
            /// <summary>
            /// 
            /// </summary>
            Laptop_Repaired = 12615,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12616 = 12616,
            /// <summary>
            /// 
            /// </summary>
            Mini_Dominion = 12617,
            /// <summary>
            /// 
            /// </summary>
            Die_soujou = 12618,
            /// <summary>
            /// 
            /// </summary>
            Decked_Decarabia = 12619,
            /// <summary>
            /// 
            /// </summary>
            Gear_Girimehkala = 12620,
            /// <summary>
            /// 
            /// </summary>
            Kinky_Kin_Ki = 12621,
            /// <summary>
            /// 
            /// </summary>
            Mossy_Mothman = 12622,
            /// <summary>
            /// 
            /// </summary>
            Movie_16_Ticket = 12623,
            /// <summary>
            /// 
            /// </summary>
            Lockpick = 12624,
            /// <summary>
            /// 
            /// </summary>
            Perma_Pick = 12625,
            /// <summary>
            /// 
            /// </summary>
            Reserve_Ammo = 12626,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12627 = 12627,
            /// <summary>
            /// 
            /// </summary>
            Treasure_Trap = 12628,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12629 = 12629,
            /// <summary>
            /// 
            /// </summary>
            Redfish = 12630,
            /// <summary>
            /// 
            /// </summary>
            Rough_Carp = 12631,
            /// <summary>
            /// 
            /// </summary>
            Tokyo_Bitterling = 12632,
            /// <summary>
            /// 
            /// </summary>
            Seven_color_Trout = 12633,
            /// <summary>
            /// 
            /// </summary>
            White_Carp = 12634,
            /// <summary>
            /// 
            /// </summary>
            Treasure_trout = 12635,
            /// <summary>
            /// 
            /// </summary>
            Delish_Bitterling = 12636,
            /// <summary>
            /// 
            /// </summary>
            Peerless_Carp = 12637,
            /// <summary>
            /// 
            /// </summary>
            Ichigaya_Guardian = 12638,
            /// <summary>
            /// 
            /// </summary>
            Adhesive_Bandage = 12639,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12640 = 12640,
            /// <summary>
            /// 
            /// </summary>
            Rejuvenating_IV = 12641,
            /// <summary>
            /// 
            /// </summary>
            Leblanc_Coffee = 12642,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12643 = 12643,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12644 = 12644,
            /// <summary>
            /// 
            /// </summary>
            Master_Coffee = 12645,
            /// <summary>
            /// 
            /// </summary>
            Decent_Curry = 12646,
            /// <summary>
            /// 
            /// </summary>
            Leblanc_Curry = 12647,
            /// <summary>
            /// 
            /// </summary>
            Master_Curry = 12648,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12649 = 12649,
            /// <summary>
            /// 
            /// </summary>
            Shooting_Card = 12650,
            /// <summary>
            /// 
            /// </summary>
            Healing_IV = 12651,
            /// <summary>
            /// 
            /// </summary>
            Railroad_Card = 12652,
            /// <summary>
            /// 
            /// </summary>
            Fighting_Card = 12653,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12654 = 12654,
            /// <summary>
            /// 
            /// </summary>
            Boxing_Card = 12655,
            /// <summary>
            /// 
            /// </summary>
            Gambling_Card = 12656,
            /// <summary>
            /// 
            /// </summary>
            Golf_Card = 12657,
            /// <summary>
            /// 
            /// </summary>
            Social_Thought = 12658,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12659 = 12659,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12660 = 12660,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12661 = 12661,
            /// <summary>
            /// 
            /// </summary>
            Batting_Science = 12662,
            /// <summary>
            /// 
            /// </summary>
            Essence_of_Fishing = 12663,
            /// <summary>
            /// 
            /// </summary>
            Speed_Reading = 12664,
            /// <summary>
            /// 
            /// </summary>
            The_Craft_of_Cinema = 12665,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12666 = 12666,
            /// <summary>
            /// 
            /// </summary>
            Chinese_Sweets = 12667,
            /// <summary>
            /// 
            /// </summary>
            Theme_Park_Escort = 12668,
            /// <summary>
            /// 
            /// </summary>
            The_Great_Thief = 12669,
            /// <summary>
            /// 
            /// </summary>
            Pirate_Legend = 12670,
            /// <summary>
            /// 
            /// </summary>
            Zorro, _the_Outlaw = 12671,
            /// <summary>
            /// 
            /// </summary>
            The_Alluring_Dancer = 12672,
            /// <summary>
            /// 
            /// </summary>
            The_Gallant_Rogue = 12673,
            /// <summary>
            /// 
            /// </summary>
            The_Illusory_Popess = 12674,
            /// <summary>
            /// 
            /// </summary>
            Cry_of_Cthulhu = 12675,
            /// <summary>
            /// 
            /// </summary>
            Woman_in_the_Dark = 12676,
            /// <summary>
            /// 
            /// </summary>
            The_Hero_with_a_Bow = 12677,
            /// <summary>
            /// 
            /// </summary>
            Medjed_Menace = 12678,
            /// <summary>
            /// 
            /// </summary>
            The_Art_of_Charm = 12679,
            /// <summary>
            /// 
            /// </summary>
            Game_Secrets = 12680,
            /// <summary>
            /// 
            /// </summary>
            Lotto_R = 12681,
            /// <summary>
            /// 
            /// </summary>
            Lotto_S = 12682,
            /// <summary>
            /// 
            /// </summary>
            Scratch_Lottery = 12683,
            /// <summary>
            /// 
            /// </summary>
            Rakugo_Collection = 12684,
            /// <summary>
            /// 
            /// </summary>
            Classical_Hits = 12685,
            /// <summary>
            /// 
            /// </summary>
            Best_of_KGB49 = 12686,
            /// <summary>
            /// 
            /// </summary>
            Wraith = 12687,
            /// <summary>
            /// 
            /// </summary>
            Jail_Break = 12688,
            /// <summary>
            /// 
            /// </summary>
            Guy_McVer = 12689,
            /// <summary>
            /// 
            /// </summary>
            The_Running_Dead = 12690,
            /// <summary>
            /// 
            /// </summary>
            The_X_Folders = 12691,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12692 = 12692,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12693 = 12693,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12694 = 12694,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12695 = 12695,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12696 = 12696,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12697 = 12697,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12698 = 12698,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12699 = 12699,
            /// <summary>
            /// 
            /// </summary>
            Vague = 12700,
            /// <summary>
            /// 
            /// </summary>
            Nightlife_Hotspots = 12701,
            /// <summary>
            /// 
            /// </summary>
            Nofeever_Sheet = 12702,
            /// <summary>
            /// 
            /// </summary>
            Hand_Warmalizer = 12703,
            /// <summary>
            /// 
            /// </summary>
            Venus_Salad = 12704,
            /// <summary>
            /// 
            /// </summary>
            Sikkenine = 12705,
            /// <summary>
            /// 
            /// </summary>
            Sikkenine_A = 12706,
            /// <summary>
            /// 
            /// </summary>
            Sikkenine_EX = 12707,
            /// <summary>
            /// 
            /// </summary>
            Wide_Eye_Drops = 12708,
            /// <summary>
            /// 
            /// </summary>
            Donut_Worry = 12709,
            /// <summary>
            /// 
            /// </summary>
            Mental_Floss = 12710,
            /// <summary>
            /// 
            /// </summary>
            Hot_and_Sour_Tea = 12711,
            /// <summary>
            /// 
            /// </summary>
            Balloons = 12712,
            /// <summary>
            /// 
            /// </summary>
            Kommissbrot = 12713,
            /// <summary>
            /// 
            /// </summary>
            Beef_Patty_Ration = 12714,
            /// <summary>
            /// 
            /// </summary>
            D_Ration = 12715,
            /// <summary>
            /// 
            /// </summary>
            Veg_Stew_Ration = 12716,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12717 = 12717,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12718 = 12718,
            /// <summary>
            /// 
            /// </summary>
            Durian_au_Lait = 12719,
            /// <summary>
            /// 
            /// </summary>
            Oh_Shiruko = 12720,
            /// <summary>
            /// 
            /// </summary>
            Chunky_Potage = 12721,
            /// <summary>
            /// 
            /// </summary>
            Ultimate_Amazake = 12722,
            /// <summary>
            /// 
            /// </summary>
            Udagawa_Soda = 12723,
            /// <summary>
            /// 
            /// </summary>
            Water_of_Rebirth = 12724,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12725 = 12725,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12726 = 12726,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12727 = 12727,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12728 = 12728,
            /// <summary>
            /// 
            /// </summary>
            Strawberry_Curry = 12729,
            /// <summary>
            /// 
            /// </summary>
            Mayo_Locust = 12730,
            /// <summary>
            /// 
            /// </summary>
            Miso_Starfish = 12731,
            /// <summary>
            /// 
            /// </summary>
            Mystery_Stew = 12732,
            /// <summary>
            /// 
            /// </summary>
            Bitter_Coffee = 12733,
            /// <summary>
            /// 
            /// </summary>
            Acidic_Coffee = 12734,
            /// <summary>
            /// 
            /// </summary>
            Fire_Curry = 12735,
            /// <summary>
            /// 
            /// </summary>
            Blaze_Curry = 12736,
            /// <summary>
            /// 
            /// </summary>
            Inferno_Curry = 12737,
            /// <summary>
            /// 
            /// </summary>
            Ramen_Bowl = 12738,
            /// <summary>
            /// 
            /// </summary>
            Night_Pennant = 12739,
            /// <summary>
            /// 
            /// </summary>
            Nude_Statue = 12740,
            /// <summary>
            /// 
            /// </summary>
            Swan_Boat = 12741,
            /// <summary>
            /// 
            /// </summary>
            Skytree_Lamp = 12742,
            /// <summary>
            /// 
            /// </summary>
            Giant_Spatula = 12743,
            /// <summary>
            /// 
            /// </summary>
            Idol_Poster = 12744,
            /// <summary>
            /// 
            /// </summary>
            Star_Stickers = 12745,
            /// <summary>
            /// 
            /// </summary>
            King_Piece = 12746,
            /// <summary>
            /// 
            /// </summary>
            Hero_Figure = 12747,
            /// <summary>
            /// 
            /// </summary>
            Hamaya = 12748,
            /// <summary>
            /// 
            /// </summary>
            I_Heart_Tokyo_Shirt = 12749,
            /// <summary>
            /// 
            /// </summary>
            Non_static_Gum = 12750,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12751 = 12751,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12752 = 12752,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12753 = 12753,
            /// <summary>
            /// 
            /// </summary>
            Kawakamis_Chocolate = 12754,
            /// <summary>
            /// 
            /// </summary>
            Takemis_Chocolate = 12755,
            /// <summary>
            /// 
            /// </summary>
            Chihayas_Chocolate = 12756,
            /// <summary>
            /// 
            /// </summary>
            Ohyas_Chocolate = 12757,
            /// <summary>
            /// 
            /// </summary>
            Hifumes_Chocolate = 12758,
            /// <summary>
            /// 
            /// </summary>
            Makotos_Chocolate = 12759,
            /// <summary>
            /// 
            /// </summary>
            Harus_Chocolate = 12760,
            /// <summary>
            /// 
            /// </summary>
            Anns_Chocolate = 12761,
            /// <summary>
            /// 
            /// </summary>
            Futabas_Chocolate = 12762,
            /// <summary>
            /// 
            /// </summary>
            Ryujis_Chocolate = 12763,
            /// <summary>
            /// 
            /// </summary>
            Sojiros_Chocolate = 12764,
            /// <summary>
            /// 
            /// </summary>
            Kumade = 12765,
            /// <summary>
            /// 
            /// </summary>
            Shumai_Cushion = 12766,
            /// <summary>
            /// 
            /// </summary>
            Gi_Nyant_Doll = 12767,
            /// <summary>
            /// 
            /// </summary>
            Sushi_Mug = 12768,
            /// <summary>
            /// 
            /// </summary>
            Choco_Fountain = 12769,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12770 = 12770,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12771 = 12771,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12772 = 12772,
            /// <summary>
            /// 
            /// </summary>
            Famidrive = 12773,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12774 = 12774,
            /// <summary>
            /// 
            /// </summary>
            Sheep_Man_Doll = 12775,
            /// <summary>
            /// 
            /// </summary>
            Jam_Bread = 12776,
            /// <summary>
            /// 
            /// </summary>
            Melon_Pan = 12777,
            /// <summary>
            /// 
            /// </summary>
            Angel_Tart = 12778,
            /// <summary>
            /// 
            /// </summary>
            Moon_Dango = 12779,
            /// <summary>
            /// 
            /// </summary>
            Mixed_Nuts = 12780,
            /// <summary>
            /// 
            /// </summary>
            Beni_Azuma = 12781,
            /// <summary>
            /// 
            /// </summary>
            Legendary_Yaki_Imo = 12782,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12783 = 12783,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12784 = 12784,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12785 = 12785,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12786 = 12786,
            /// <summary>
            /// 
            /// </summary>
            Moonlight_Carrot = 12787,
            /// <summary>
            /// 
            /// </summary>
            Sun_Tomato = 12788,
            /// <summary>
            /// 
            /// </summary>
            Earth_Beans = 12789,
            /// <summary>
            /// 
            /// </summary>
            Star_Onion = 12790,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12791 = 12791,
            /// <summary>
            /// 
            /// </summary>
            Ann_Cream_Puffs = 12792,
            /// <summary>
            /// 
            /// </summary>
            Makoto_Donuts = 12793,
            /// <summary>
            /// 
            /// </summary>
            Sakura_Amazaiku = 12794,
            /// <summary>
            /// 
            /// </summary>
            Sadayo_Taiyaki = 12795,
            /// <summary>
            /// 
            /// </summary>
            Ryuji_Dog = 12796,
            /// <summary>
            /// 
            /// </summary>
            Amateur_Curry = 12797,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12798 = 12798,
            /// <summary>
            /// 
            /// </summary>
            Broken_Laptop = 12799,
            /// <summary>
            /// 
            /// </summary>
            Imported_Protein = 12800,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12801 = 12801,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12802 = 12802,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12803 = 12803,
            /// <summary>
            /// 
            /// </summary>
            Aquarium_a_Day = 12804,
            /// <summary>
            /// 
            /// </summary>
            Nakano_Walker = 12805,
            /// <summary>
            /// 
            /// </summary>
            Incense_ST = 12806,
            /// <summary>
            /// 
            /// </summary>
            Incense_MA = 12807,
            /// <summary>
            /// 
            /// </summary>
            Incense_EN = 12808,
            /// <summary>
            /// 
            /// </summary>
            Incense_AG = 12809,
            /// <summary>
            /// 
            /// </summary>
            Incense_LU = 12810,
            /// <summary>
            /// 
            /// </summary>
            Ambergris_ST = 12811,
            /// <summary>
            /// 
            /// </summary>
            Ambergris_MA = 12812,
            /// <summary>
            /// 
            /// </summary>
            Ambergris_EN = 12813,
            /// <summary>
            /// 
            /// </summary>
            Ambergris_AG = 12814,
            /// <summary>
            /// 
            /// </summary>
            Ambergris_LU = 12815,
            /// <summary>
            /// 
            /// </summary>
            Nirvana_ST = 12816,
            /// <summary>
            /// 
            /// </summary>
            Nirvana_MA = 12817,
            /// <summary>
            /// 
            /// </summary>
            Nirvana_EN = 12818,
            /// <summary>
            /// 
            /// </summary>
            Nirvana_AG = 12819,
            /// <summary>
            /// 
            /// </summary>
            Nirvana_LU = 12820,
            /// <summary>
            /// 
            /// </summary>
            Chunky_Katsu = 12821,
            /// <summary>
            /// 
            /// </summary>
            Stronger_Lift_S = 12822,
            /// <summary>
            /// 
            /// </summary>
            Harder_Core_S = 12823,
            /// <summary>
            /// 
            /// </summary>
            Accu_Speed_S = 12824,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12825 = 12825,
            /// <summary>
            /// 
            /// </summary>
            Sakura_Mochi = 12826,
            /// <summary>
            /// 
            /// </summary>
            Oil_Painting_Set = 12827,
            /// <summary>
            /// 
            /// </summary>
            Water_Color_Postcard = 12828,
            /// <summary>
            /// 
            /// </summary>
            Leather_Pen_Case = 12829,
            /// <summary>
            /// 
            /// </summary>
            Cup_Noodle_Set = 12830,
            /// <summary>
            /// 
            /// </summary>
            Omni_Vitamin = 12831,
            /// <summary>
            /// 
            /// </summary>
            Silver_Bangle = 12832,
            /// <summary>
            /// 
            /// </summary>
            Wrist_Weights = 12833,
            /// <summary>
            /// 
            /// </summary>
            Sports_Sunglasses = 12834,
            /// <summary>
            /// 
            /// </summary>
            Kitchen_Tools_Set = 12835,
            /// <summary>
            /// 
            /// </summary>
            _48_Sided_3D_Puzzle = 12836,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12837 = 12837,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12838 = 12838,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12839 = 12839,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12840 = 12840,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12841 = 12841,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12842 = 12842,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12843 = 12843,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12844 = 12844,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12845 = 12845,
            /// <summary>
            /// 
            /// </summary>
            Dizzy_Vial_S = 12846,
            /// <summary>
            /// 
            /// </summary>
            Dizzy_Vial_L = 12847,
            /// <summary>
            /// 
            /// </summary>
            Confuse_Vial_S = 12848,
            /// <summary>
            /// 
            /// </summary>
            Confuse_Vial_L = 12849,
            /// <summary>
            /// 
            /// </summary>
            Fear_Vial_S = 12850,
            /// <summary>
            /// 
            /// </summary>
            Fear_Vial_L = 12851,
            /// <summary>
            /// 
            /// </summary>
            Forget_Vial_S = 12852,
            /// <summary>
            /// 
            /// </summary>
            Forget_Vial_L = 12853,
            /// <summary>
            /// 
            /// </summary>
            Sleep_Vial_S = 12854,
            /// <summary>
            /// 
            /// </summary>
            Sleep_Vial_L = 12855,
            /// <summary>
            /// 
            /// </summary>
            Rage_Vial_S = 12856,
            /// <summary>
            /// 
            /// </summary>
            Rage_Vial_L = 12857,
            /// <summary>
            /// 
            /// </summary>
            Despair_Vial_S = 12858,
            /// <summary>
            /// 
            /// </summary>
            Despair_Vial_L = 12859,
            /// <summary>
            /// 
            /// </summary>
            Brainwash_Vial_S = 12860,
            /// <summary>
            /// 
            /// </summary>
            Brainwash_Vial_L = 12861,
            /// <summary>
            /// 
            /// </summary>
            Musk_ST_MA = 12862,
            /// <summary>
            /// 
            /// </summary>
            Musk_ST_EN = 12863,
            /// <summary>
            /// 
            /// </summary>
            Musk_ST_AG = 12864,
            /// <summary>
            /// 
            /// </summary>
            Musk_ST_LU = 12865,
            /// <summary>
            /// 
            /// </summary>
            Musk_MA_EN = 12866,
            /// <summary>
            /// 
            /// </summary>
            Musk_MA_AG = 12867,
            /// <summary>
            /// 
            /// </summary>
            Musk_MA_LU = 12868,
            /// <summary>
            /// 
            /// </summary>
            Musk_EN_AG = 12869,
            /// <summary>
            /// 
            /// </summary>
            Musk_EN_LU = 12870,
            /// <summary>
            /// 
            /// </summary>
            Rasta_Sandalwood = 12871,
            /// <summary>
            /// 
            /// </summary>
            Featherman_Seeker = 12872,
            /// <summary>
            /// 
            /// </summary>
            Feather_Card = 12873,
            /// <summary>
            /// 
            /// </summary>
            Batting_Coupon = 12874,
            /// <summary>
            /// 
            /// </summary>
            Salvation_S = 12875,
            /// <summary>
            /// 
            /// </summary>
            Ichigaya_Kingpin = 12876,
            /// <summary>
            /// 
            /// </summary>
            Black_Frost_Doll = 12877,
            /// <summary>
            /// 
            /// </summary>
            Buchimaru_Doll = 12878,
            /// <summary>
            /// 
            /// </summary>
            Jagao_Doll = 12879,
            /// <summary>
            /// 
            /// </summary>
            Suspicious_Boilie = 12880,
            /// <summary>
            /// 
            /// </summary>
            Hi_Tech_Rod = 12881,
            /// <summary>
            /// 
            /// </summary>
            Sea_Slug_Rod = 12882,
            /// <summary>
            /// 
            /// </summary>
            Feathermen_Dolls = 12883,
            /// <summary>
            /// 
            /// </summary>
            Sumires_Chocolate = 12884,
            /// <summary>
            /// 
            /// </summary>
            Anns_Giri_Choco = 12885,
            /// <summary>
            /// 
            /// </summary>
            Makotos_Giri_Choco = 12886,
            /// <summary>
            /// 
            /// </summary>
            Harus_Giri_Choco = 12887,
            /// <summary>
            /// 
            /// </summary>
            Futabas_Giri_Choco = 12888,
            /// <summary>
            /// 
            /// </summary>
            Takemis_Giri_Choco = 12889,
            /// <summary>
            /// 
            /// </summary>
            Chihayas_Giri_Choco = 12890,
            /// <summary>
            /// 
            /// </summary>
            Kawakamis_Giri_Choco = 12891,
            /// <summary>
            /// 
            /// </summary>
            Ohyas_Giri_Choco = 12892,
            /// <summary>
            /// 
            /// </summary>
            Hifumis_Giri_Choco = 12893,
            /// <summary>
            /// 
            /// </summary>
            Sumires_Giri_Choco = 12894,
            /// <summary>
            /// 
            /// </summary>
            Saes_Giri_Choco = 12895,
            /// <summary>
            /// 
            /// </summary>
            Makotos_Candy = 12896,
            /// <summary>
            /// 
            /// </summary>
            Harus_Candy = 12897,
            /// <summary>
            /// 
            /// </summary>
            Anns_Candy = 12898,
            /// <summary>
            /// 
            /// </summary>
            Futabas_Candy = 12899,
            /// <summary>
            /// 
            /// </summary>
            Chihayas_Candy = 12900,
            /// <summary>
            /// 
            /// </summary>
            Takemis_Candy = 12901,
            /// <summary>
            /// 
            /// </summary>
            Kawakamis_Candy = 12902,
            /// <summary>
            /// 
            /// </summary>
            Ohyas_Candy = 12903,
            /// <summary>
            /// 
            /// </summary>
            Hifumis_Candy = 12904,
            /// <summary>
            /// 
            /// </summary>
            Sumires_Candy = 12905,
            /// <summary>
            /// 
            /// </summary>
            Scarlet_Rose = 12906,
            /// <summary>
            /// 
            /// </summary>
            Yellow_Gerbera = 12907,
            /// <summary>
            /// 
            /// </summary>
            Blue_Hyacinth = 12908,
            /// <summary>
            /// 
            /// </summary>
            Stamina_Kit_S = 12909,
            /// <summary>
            /// 
            /// </summary>
            Stamina_Kit_L = 12910,
            /// <summary>
            /// 
            /// </summary>
            Dart_Set = 12911,
            /// <summary>
            /// 
            /// </summary>
            Jump_Cue = 12912,
            /// <summary>
            /// 
            /// </summary>
            Royal_Jelly_R = 12913,
            /// <summary>
            /// 
            /// </summary>
            Strawberry_Daifuku = 12914,
            /// <summary>
            /// 
            /// </summary>
            Learn_Pro_Darts = 12915,
            /// <summary>
            /// 
            /// </summary>
            Expert_Billiards = 12916,
            /// <summary>
            /// 
            /// </summary>
            D_Housewives = 12917,
            /// <summary>
            /// 
            /// </summary>
            Mouse_MD = 12918,
            /// <summary>
            /// 
            /// </summary>
            _31 = 12919,
            /// <summary>
            /// 
            /// </summary>
            Tee = 12920,
            /// <summary>
            /// 
            /// </summary>
            Stamp_Card = 12921,
            /// <summary>
            /// 
            /// </summary>
            Photo_of_Clara = 12922,
            /// <summary>
            /// 
            /// </summary>
            Bland_Cheese = 12923,
            /// <summary>
            /// 
            /// </summary>
            Sharp_Cheese = 12924,
            /// <summary>
            /// 
            /// </summary>
            Rich_Cheese = 12925,
            /// <summary>
            /// 
            /// </summary>
            Pumpkin_Soup = 12926,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12927 = 12927,
            /// <summary>
            /// 
            /// </summary>
            Puzzle_Rings = 12928,
            /// <summary>
            /// 
            /// </summary>
            Mochi_Cushion = 12929,
            /// <summary>
            /// 
            /// </summary>
            Electric_Toothbrush = 12930,
            /// <summary>
            /// 
            /// </summary>
            Blaring_Alarm_Clock = 12931,
            /// <summary>
            /// 
            /// </summary>
            Aroma_Machine = 12932,
            /// <summary>
            /// 
            /// </summary>
            Katana_Keychain = 12933,
            /// <summary>
            /// 
            /// </summary>
            Factorization_Guide = 12934,
            /// <summary>
            /// 
            /// </summary>
            Hustle_S = 12935,
            /// <summary>
            /// 
            /// </summary>
            Viennese_Jelly = 12936,
            /// <summary>
            /// 
            /// </summary>
            Weakener_Spray = 12937,
            /// <summary>
            /// 
            /// </summary>
            Cleaning_Spray = 12938,
            /// <summary>
            /// 
            /// </summary>
            Quick_Spray = 12939,
            /// <summary>
            /// 
            /// </summary>
            Ultimate_Spray = 12940,
            /// <summary>
            /// 
            /// </summary>
            Awake_Incense = 12941,
            /// <summary>
            /// 
            /// </summary>
            Awakening_Incense = 12942,
            /// <summary>
            /// 
            /// </summary>
            Unused_12943 = 12943,
            /// <summary>
            /// 
            /// </summary>
            Unused_12944 = 12944,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12945 = 12945,
            /// <summary>
            /// 
            /// </summary>
            Dressed_in_Ashes = 12946,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_12947 = 12947,
            /// <summary>
            /// 
            /// </summary>
            Hogyoku_Apple = 12948,
            /// <summary>
            /// 
            /// </summary>
            Band_Ace = 12949,
            /// <summary>
            /// 
            /// </summary>
            Holy_Shroud = 12950,
            /// <summary>
            /// 
            /// </summary>
            Ouija_Board = 12951,
            /// <summary>
            /// 
            /// </summary>
            Empowering_Ofuda = 12952,
            /// <summary>
            /// 
            /// </summary>
            Debilitator_Ofuda = 12953,
            /// <summary>
            /// 
            /// </summary>
            Fire_Magatama = 12954,
            /// <summary>
            /// 
            /// </summary>
            Gale_Magatama = 12955,
            /// <summary>
            /// 
            /// </summary>
            Shock_Magatama = 12956,
            /// <summary>
            /// 
            /// </summary>
            Ice_Magatama = 12957,
            /// <summary>
            /// 
            /// </summary>
            Nuke_Magatama = 12958,
            /// <summary>
            /// 
            /// </summary>
            Psy_Magatama = 12959,
            /// <summary>
            /// 
            /// </summary>
            Bless_Magatama = 12960,
            /// <summary>
            /// 
            /// </summary>
            Curse_Magatama = 12961,
            /// <summary>
            /// 
            /// </summary>
            Invincible_Ofuda = 12962,
            /// <summary>
            /// 
            /// </summary>
            Strength_Up_Ofuda = 12963,
            /// <summary>
            /// 
            /// </summary>
            Magic_Up_Ofuda = 12964,
            /// <summary>
            /// 
            /// </summary>
            Seekers_Tools = 12965,
            /// <summary>
            /// 
            /// </summary>
            ABCs_of_Crafting = 12966,
            /// <summary>
            /// 
            /// </summary>
            Juicy_Nikuman = 12967,
            /// <summary>
            /// 
            /// </summary>
            Napolitan_Nikuman = 12968,
            /// <summary>
            /// 
            /// </summary>
            Peppery_Nikuman = 12969,
            /// <summary>
            /// 
            /// </summary>
            Corned_Beef_Special = 12970,
            /// <summary>
            /// 
            /// </summary>
            Cereal_Multi_Pack = 12971,
            /// <summary>
            /// 
            /// </summary>
            Popcorn_Bomb = 12972,
            /// <summary>
            /// 
            /// </summary>
            Clothing_Grab_Bag = 12973,
            /// <summary>
            /// 
            /// </summary>
            Osechi_Ration = 12974,
            /// <summary>
            /// 
            /// </summary>
            Mont_Blanc_Ration = 12975,
            /// <summary>
            /// 
            /// </summary>
            Kebab_Ration = 12976,
            /// <summary>
            /// 
            /// </summary>
            Special_Chimaki = 12977,
            /// <summary>
            /// 
            /// </summary>
            Osechi_Chocolate = 12978,
            /// <summary>
            /// 
            /// </summary>
            Knowing_the_Heart = 12979,
            /// <summary>
            /// 
            /// </summary>
            The_Fader = 12980,
            /// <summary>
            /// 
            /// </summary>
            Old_Mans_Elixier = 12981,
            /// <summary>
            /// 
            /// </summary>
            Billiards_Magician = 12982,
            /// <summary>
            /// 
            /// </summary>
            Musk_AG_LU = 12983,
            /// <summary>
            /// 
            /// </summary>
            BLANK_16384 = 16384,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16385 = 16385,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16386 = 16386,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16387 = 16387,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16388 = 16388,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16389 = 16389,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16390 = 16390,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16391 = 16391,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16392 = 16392,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16393 = 16393,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16394 = 16394,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16395 = 16395,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16396 = 16396,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16397 = 16397,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16398 = 16398,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16399 = 16399,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16400 = 16400,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16401 = 16401,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16402 = 16402,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16403 = 16403,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16404 = 16404,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16405 = 16405,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16406 = 16406,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16407 = 16407,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16408 = 16408,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16409 = 16409,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16410 = 16410,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16411 = 16411,
            /// <summary>
            /// 
            /// </summary>
            Unused_16412 = 16412,
            /// <summary>
            /// 
            /// </summary>
            Unused_16413 = 16413,
            /// <summary>
            /// 
            /// </summary>
            Key_to_Leblanc = 16414,
            /// <summary>
            /// 
            /// </summary>
            Paper_Bag = 16415,
            /// <summary>
            /// 
            /// </summary>
            Unused_16416 = 16416,
            /// <summary>
            /// 
            /// </summary>
            Unused_16417 = 16417,
            /// <summary>
            /// 
            /// </summary>
            Unused_16418 = 16418,
            /// <summary>
            /// 
            /// </summary>
            Old_Key = 16419,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16420 = 16420,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16421 = 16421,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16422 = 16422,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16423 = 16423,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16424 = 16424,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16425 = 16425,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16426 = 16426,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16427 = 16427,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16428 = 16428,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16429 = 16429,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16430 = 16430,
            /// <summary>
            /// 
            /// </summary>
            Unused_16431 = 16431,
            /// <summary>
            /// 
            /// </summary>
            Evil_Snow_Crystal = 16432,
            /// <summary>
            /// 
            /// </summary>
            Sticky_Hairball = 16433,
            /// <summary>
            /// 
            /// </summary>
            Double_Bookmark = 16434,
            /// <summary>
            /// 
            /// </summary>
            Unused_16435 = 16435,
            /// <summary>
            /// 
            /// </summary>
            Pen_Case = 16436,
            /// <summary>
            /// 
            /// </summary>
            Muffler = 16437,
            /// <summary>
            /// 
            /// </summary>
            Cologne = 16438,
            /// <summary>
            /// 
            /// </summary>
            Camera = 16439,
            /// <summary>
            /// 
            /// </summary>
            Gloves = 16440,
            /// <summary>
            /// 
            /// </summary>
            Wristwatch = 16441,
            /// <summary>
            /// 
            /// </summary>
            Hat = 16442,
            /// <summary>
            /// 
            /// </summary>
            Earmuffs = 16443,
            /// <summary>
            /// 
            /// </summary>
            Headphones_16444 = 16444,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16445 = 16445,
            /// <summary>
            /// 
            /// </summary>
            Buchi_Calculator = 16446,
            /// <summary>
            /// 
            /// </summary>
            Dyed_Handkerchief = 16447,
            /// <summary>
            /// 
            /// </summary>
            Fashion_Magazine = 16448,
            /// <summary>
            /// 
            /// </summary>
            Promise_List = 16449,
            /// <summary>
            /// 
            /// </summary>
            Unlimited_Service = 16450,
            /// <summary>
            /// 
            /// </summary>
            Dog_Tag = 16451,
            /// <summary>
            /// 
            /// </summary>
            Fortune_Tarot_Card = 16452,
            /// <summary>
            /// 
            /// </summary>
            Interview_Notes = 16453,
            /// <summary>
            /// 
            /// </summary>
            Kosha_Piece = 16454,
            /// <summary>
            /// 
            /// </summary>
            Sports_Watch = 16455,
            /// <summary>
            /// 
            /// </summary>
            Morganas_Scarf = 16456,
            /// <summary>
            /// 
            /// </summary>
            Recipe_Notes = 16457,
            /// <summary>
            /// 
            /// </summary>
            Documentary_Plans = 16458,
            /// <summary>
            /// 
            /// </summary>
            Gecko_Pin = 16459,
            /// <summary>
            /// 
            /// </summary>
            Cell_Key = 16460,
            /// <summary>
            /// 
            /// </summary>
            Desire_and_Hope = 16461,
            /// <summary>
            /// 
            /// </summary>
            Fountain_Pen_16462 = 16462,
            /// <summary>
            /// 
            /// </summary>
            Gun_Controller = 16463,
            /// <summary>
            /// 
            /// </summary>
            Business_Card = 16464,
            /// <summary>
            /// 
            /// </summary>
            Leather_Gloves = 16465,
            /// <summary>
            /// 
            /// </summary>
            Gymnastics_Baton = 16466,
            /// <summary>
            /// 
            /// </summary>
            Research_Notebook = 16467,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16468 = 16468,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16469 = 16469,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16470 = 16470,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16471 = 16471,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16472 = 16472,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16473 = 16473,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16474 = 16474,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16475 = 16475,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16476 = 16476,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16477 = 16477,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16478 = 16478,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16479 = 16479,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16480 = 16480,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16481 = 16481,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16482 = 16482,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16483 = 16483,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16484 = 16484,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16485 = 16485,
            /// <summary>
            /// 
            /// </summary>
            Castle_Map = 16486,
            /// <summary>
            /// 
            /// </summary>
            Tower_Map = 16487,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16488 = 16488,
            /// <summary>
            /// 
            /// </summary>
            Kamoshidas_Medal = 16489,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16490 = 16490,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16491 = 16491,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16492 = 16492,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16493 = 16493,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16494 = 16494,
            /// <summary>
            /// 
            /// </summary>
            The_King_Book = 16495,
            /// <summary>
            /// 
            /// </summary>
            The_Queen_Book = 16496,
            /// <summary>
            /// 
            /// </summary>
            The_Slave_Book = 16497,
            /// <summary>
            /// 
            /// </summary>
            Green_Key = 16498,
            /// <summary>
            /// 
            /// </summary>
            Red_Key = 16499,
            /// <summary>
            /// 
            /// </summary>
            Randy_Right_Eye = 16500,
            /// <summary>
            /// 
            /// </summary>
            Lustful_Left_Eye = 16501,
            /// <summary>
            /// 
            /// </summary>
            Right_Key = 16502,
            /// <summary>
            /// 
            /// </summary>
            Left_Key = 16503,
            /// <summary>
            /// 
            /// </summary>
            Kaneshiros_Journal = 16504,
            /// <summary>
            /// 
            /// </summary>
            Torn_Page_1 = 16505,
            /// <summary>
            /// 
            /// </summary>
            Torn_Page_2 = 16506,
            /// <summary>
            /// 
            /// </summary>
            Torn_Page_3 = 16507,
            /// <summary>
            /// 
            /// </summary>
            Torn_Page_4 = 16508,
            /// <summary>
            /// 
            /// </summary>
            Torn_Page_5 = 16509,
            /// <summary>
            /// 
            /// </summary>
            Torn_Page_6 = 16510,
            /// <summary>
            /// 
            /// </summary>
            Abyss_Gem = 16511,
            /// <summary>
            /// 
            /// </summary>
            Rejection_Gem = 16512,
            /// <summary>
            /// 
            /// </summary>
            Guilt_Gem = 16513,
            /// <summary>
            /// 
            /// </summary>
            Sanctuary_Gem = 16514,
            /// <summary>
            /// 
            /// </summary>
            Members_Card = 16515,
            /// <summary>
            /// 
            /// </summary>
            Stolen_Papyrus = 16516,
            /// <summary>
            /// 
            /// </summary>
            Pyramid_Sketch = 16517,
            /// <summary>
            /// 
            /// </summary>
            Members_Foor_Map = 16518,
            /// <summary>
            /// 
            /// </summary>
            High_Limit_Floor_Map = 16519,
            /// <summary>
            /// 
            /// </summary>
            Basement_Blueprint = 16520,
            /// <summary>
            /// 
            /// </summary>
            High_Limit_Card = 16521,
            /// <summary>
            /// 
            /// </summary>
            Spaceport_Map = 16522,
            /// <summary>
            /// 
            /// </summary>
            Chief_Clerk_ID = 16523,
            /// <summary>
            /// 
            /// </summary>
            Section_Chief_ID = 16524,
            /// <summary>
            /// 
            /// </summary>
            Chief_Director_ID = 16525,
            /// <summary>
            /// 
            /// </summary>
            Museum_Brochure_1 = 16526,
            /// <summary>
            /// 
            /// </summary>
            Museum_Brochure_2 = 16527,
            /// <summary>
            /// 
            /// </summary>
            Bank_Blueprint = 16528,
            /// <summary>
            /// 
            /// </summary>
            Bank_Keycard = 16529,
            /// <summary>
            /// 
            /// </summary>
            Casino_Map = 16530,
            /// <summary>
            /// 
            /// </summary>
            Security_Keycard = 16531,
            /// <summary>
            /// 
            /// </summary>
            Cruise_Ship_Map = 16532,
            /// <summary>
            /// 
            /// </summary>
            Membership_Card = 16533,
            /// <summary>
            /// 
            /// </summary>
            Vip_Invitation = 16534,
            /// <summary>
            /// 
            /// </summary>
            Vermilion_Disk = 16535,
            /// <summary>
            /// 
            /// </summary>
            Vermilion_Disk_16536 = 16536,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16537 = 16537,
            /// <summary>
            /// 
            /// </summary>
            Grappling_Hook = 16538,
            /// <summary>
            /// 
            /// </summary>
            Building_Blueprint = 16539,
            /// <summary>
            /// 
            /// </summary>
            Lab_Blueprint = 16540,
            /// <summary>
            /// 
            /// </summary>
            Personnel_ID = 16541,
            /// <summary>
            /// 
            /// </summary>
            Old_Videotape = 16542,
            /// <summary>
            /// 
            /// </summary>
            Unused_16543 = 16543,
            /// <summary>
            /// 
            /// </summary>
            The_Beefcake_Book = 16544,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16545 = 16545,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16546 = 16546,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16547 = 16547,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16548 = 16548,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16549 = 16549,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16550 = 16550,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16551 = 16551,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16552 = 16552,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16553 = 16553,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16554 = 16554,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16555 = 16555,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16556 = 16556,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16557 = 16557,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16558 = 16558,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16559 = 16559,
            /// <summary>
            /// 
            /// </summary>
            Unused_16560 = 16560,
            /// <summary>
            /// 
            /// </summary>
            Unused_16561 = 16561,
            /// <summary>
            /// 
            /// </summary>
            Unused_16562 = 16562,
            /// <summary>
            /// 
            /// </summary>
            Unused_16563 = 16563,
            /// <summary>
            /// 
            /// </summary>
            Unused_16564 = 16564,
            /// <summary>
            /// 
            /// </summary>
            Unused_16565 = 16565,
            /// <summary>
            /// 
            /// </summary>
            Unused_16566 = 16566,
            /// <summary>
            /// 
            /// </summary>
            Unused_16567 = 16567,
            /// <summary>
            /// 
            /// </summary>
            Unused_16568 = 16568,
            /// <summary>
            /// 
            /// </summary>
            Unused_16569 = 16569,
            /// <summary>
            /// 
            /// </summary>
            Unused_16570 = 16570,
            /// <summary>
            /// 
            /// </summary>
            Unused_16571 = 16571,
            /// <summary>
            /// 
            /// </summary>
            Unused_16572 = 16572,
            /// <summary>
            /// 
            /// </summary>
            Unused_16573 = 16573,
            /// <summary>
            /// 
            /// </summary>
            Unused_16574 = 16574,
            /// <summary>
            /// 
            /// </summary>
            Unused_16575 = 16575,
            /// <summary>
            /// 
            /// </summary>
            Unused_16576 = 16576,
            /// <summary>
            /// 
            /// </summary>
            Unused_16577 = 16577,
            /// <summary>
            /// 
            /// </summary>
            Unused_16578 = 16578,
            /// <summary>
            /// 
            /// </summary>
            Unused_16579 = 16579,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16580 = 16580,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16581 = 16581,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16582 = 16582,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16583 = 16583,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16584 = 16584,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16585 = 16585,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16586 = 16586,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16587 = 16587,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16588 = 16588,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16589 = 16589,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16590 = 16590,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16591 = 16591,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16592 = 16592,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16593 = 16593,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16594 = 16594,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16595 = 16595,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16596 = 16596,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16597 = 16597,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16598 = 16598,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16599 = 16599,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16600 = 16600,
            /// <summary>
            /// 
            /// </summary>
            Stamp_Book = 16601,
            /// <summary>
            /// 
            /// </summary>
            Star_Lilinas_New_CD = 16602,
            /// <summary>
            /// 
            /// </summary>
            Small_Key = 16603,
            /// <summary>
            /// 
            /// </summary>
            Joses_Star = 16604,
            /// <summary>
            /// 
            /// </summary>
            Intricate_Bookmark = 16605,
            /// <summary>
            /// 
            /// </summary>
            Star_Water_Tray = 16606,
            /// <summary>
            /// 
            /// </summary>
            Letter_from_Royalty = 16607,
            /// <summary>
            /// 
            /// </summary>
            Free_Darts_Ticket = 16608,
            /// <summary>
            /// 
            /// </summary>
            Red_Lust_Seed = 16609,
            /// <summary>
            /// 
            /// </summary>
            Green_Lust_Seed = 16610,
            /// <summary>
            /// 
            /// </summary>
            Blue_Lust_Seed = 16611,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16612 = 16612,
            /// <summary>
            /// 
            /// </summary>
            Red_Vanity_Seed = 16613,
            /// <summary>
            /// 
            /// </summary>
            Green_Vanity_Seed = 16614,
            /// <summary>
            /// 
            /// </summary>
            Blue_Vanity_Seed = 16615,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16616 = 16616,
            /// <summary>
            /// 
            /// </summary>
            Red_Gluttony_Seed = 16617,
            /// <summary>
            /// 
            /// </summary>
            Green_Gluttony_Seed = 16618,
            /// <summary>
            /// 
            /// </summary>
            Blue_Gluttony_Seed = 16619,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16620 = 16620,
            /// <summary>
            /// 
            /// </summary>
            Red_Wrath_Seed = 16621,
            /// <summary>
            /// 
            /// </summary>
            Green_Wrath_Seed = 16622,
            /// <summary>
            /// 
            /// </summary>
            Blue_Wrath_Seed = 16623,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16624 = 16624,
            /// <summary>
            /// 
            /// </summary>
            Red_Greed_Seed = 16625,
            /// <summary>
            /// 
            /// </summary>
            Green_Greed_Seed = 16626,
            /// <summary>
            /// 
            /// </summary>
            Blue_Greed_Seed = 16627,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16628 = 16628,
            /// <summary>
            /// 
            /// </summary>
            Red_Jealousy_Seed = 16629,
            /// <summary>
            /// 
            /// </summary>
            Green_Jealousy_Seed = 16630,
            /// <summary>
            /// 
            /// </summary>
            Blue_Jealousy_Seed = 16631,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16632 = 16632,
            /// <summary>
            /// 
            /// </summary>
            Red_Pride_Seed = 16633,
            /// <summary>
            /// 
            /// </summary>
            Green_Pride_Seed = 16634,
            /// <summary>
            /// 
            /// </summary>
            Blue_Pride_Seed = 16635,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_16636 = 16636,
            /// <summary>
            /// 
            /// </summary>
            Red_Sorrow_Seed = 16637,
            /// <summary>
            /// 
            /// </summary>
            Green_Sorrow_Seed = 16638,
            /// <summary>
            /// 
            /// </summary>
            Blue_Sorrow_Seed = 16639,
            /// <summary>
            /// 
            /// </summary>
            BLANK_20480 = 20480,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20481 = 20481,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20482 = 20482,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20483 = 20483,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20484 = 20484,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20485 = 20485,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20486 = 20486,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20487 = 20487,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20488 = 20488,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20489 = 20489,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20490 = 20490,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20491 = 20491,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20492 = 20492,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20493 = 20493,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20494 = 20494,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20495 = 20495,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20496 = 20496,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20497 = 20497,
            /// <summary>
            /// 
            /// </summary>
            Glory_Staff = 20498,
            /// <summary>
            /// 
            /// </summary>
            Blessed_Trumpet = 20499,
            /// <summary>
            /// 
            /// </summary>
            Victor_Laurel = 20500,
            /// <summary>
            /// 
            /// </summary>
            Porcelain_Teacup = 20501,
            /// <summary>
            /// 
            /// </summary>
            Silver_Cutlery = 20502,
            /// <summary>
            /// 
            /// </summary>
            Strange_Lantern = 20503,
            /// <summary>
            /// 
            /// </summary>
            Nude_Candle_Stand = 20504,
            /// <summary>
            /// 
            /// </summary>
            Shackles = 20505,
            /// <summary>
            /// 
            /// </summary>
            Locked_Collar = 20506,
            /// <summary>
            /// 
            /// </summary>
            Dull_Sword = 20507,
            /// <summary>
            /// 
            /// </summary>
            Holey_Helmet = 20508,
            /// <summary>
            /// 
            /// </summary>
            Crushed_Shield = 20509,
            /// <summary>
            /// 
            /// </summary>
            Rusted_Handcuffs = 20510,
            /// <summary>
            /// 
            /// </summary>
            Chipped_Glass = 20511,
            /// <summary>
            /// 
            /// </summary>
            Ukiyo_e = 20512,
            /// <summary>
            /// 
            /// </summary>
            Ink_Wash_Art = 20513,
            /// <summary>
            /// 
            /// </summary>
            Hanging_Scroll = 20514,
            /// <summary>
            /// 
            /// </summary>
            Picture_Scroll = 20515,
            /// <summary>
            /// 
            /// </summary>
            Hannya_Mask = 20516,
            /// <summary>
            /// 
            /// </summary>
            Animal_Brush = 20517,
            /// <summary>
            /// 
            /// </summary>
            Fine_Washi = 20518,
            /// <summary>
            /// 
            /// </summary>
            Loose_Sash = 20519,
            /// <summary>
            /// 
            /// </summary>
            Cracked_Vase = 20520,
            /// <summary>
            /// 
            /// </summary>
            Sooty_Kettle = 20521,
            /// <summary>
            /// 
            /// </summary>
            Unsigned_Mug = 20522,
            /// <summary>
            /// 
            /// </summary>
            Plastic_Frame = 20523,
            /// <summary>
            /// 
            /// </summary>
            Crappy_Portrait = 20524,
            /// <summary>
            /// 
            /// </summary>
            Bad_Sculpture = 20525,
            /// <summary>
            /// 
            /// </summary>
            Gold_Coin = 20526,
            /// <summary>
            /// 
            /// </summary>
            Stock_Certificate = 20527,
            /// <summary>
            /// 
            /// </summary>
            Amber_Stamp = 20528,
            /// <summary>
            /// 
            /// </summary>
            Precious_Bill = 20529,
            /// <summary>
            /// 
            /// </summary>
            Rare_Coin = 20530,
            /// <summary>
            /// 
            /// </summary>
            Old_Coin = 20531,
            /// <summary>
            /// 
            /// </summary>
            Leather_Case = 20532,
            /// <summary>
            /// 
            /// </summary>
            Safe_Dial = 20533,
            /// <summary>
            /// 
            /// </summary>
            Money_Counter = 20534,
            /// <summary>
            /// 
            /// </summary>
            Office_Calculator = 20535,
            /// <summary>
            /// 
            /// </summary>
            Inkless_Pen = 20536,
            /// <summary>
            /// 
            /// </summary>
            Unopenable_Lock = 20537,
            /// <summary>
            /// 
            /// </summary>
            Worn_Stamp = 20538,
            /// <summary>
            /// 
            /// </summary>
            Tattered_Wallet = 20539,
            /// <summary>
            /// 
            /// </summary>
            Jewel_Mummy = 20540,
            /// <summary>
            /// 
            /// </summary>
            Gold_Uraeus = 20541,
            /// <summary>
            /// 
            /// </summary>
            Canopic_Jar = 20542,
            /// <summary>
            /// 
            /// </summary>
            Bastet_Statue = 20543,
            /// <summary>
            /// 
            /// </summary>
            Scarab_Charm = 20544,
            /// <summary>
            /// 
            /// </summary>
            Mummy_Mask = 20545,
            /// <summary>
            /// 
            /// </summary>
            Scratched_Sword = 20546,
            /// <summary>
            /// 
            /// </summary>
            Rusted_Ankh = 20547,
            /// <summary>
            /// 
            /// </summary>
            Torn_Papyrus = 20548,
            /// <summary>
            /// 
            /// </summary>
            Ra_Mural = 20549,
            /// <summary>
            /// 
            /// </summary>
            Sekhmet_Mural = 20550,
            /// <summary>
            /// 
            /// </summary>
            Sarcophagus_Bit = 20551,
            /// <summary>
            /// 
            /// </summary>
            Bent_Staff = 20552,
            /// <summary>
            /// 
            /// </summary>
            Pillar_Piece = 20553,
            /// <summary>
            /// 
            /// </summary>
            Moon_Stone = 20554,
            /// <summary>
            /// 
            /// </summary>
            Rare_Metal = 20555,
            /// <summary>
            /// 
            /// </summary>
            Sage_Astrolabe = 20556,
            /// <summary>
            /// 
            /// </summary>
            UFO_Drone = 20557,
            /// <summary>
            /// 
            /// </summary>
            Blade_Flashlight = 20558,
            /// <summary>
            /// 
            /// </summary>
            Rainbow_Diode = 20559,
            /// <summary>
            /// 
            /// </summary>
            Spaceship_Stick = 20560,
            /// <summary>
            /// 
            /// </summary>
            Robot_Arm = 20561,
            /// <summary>
            /// 
            /// </summary>
            Radar_Antenna = 20562,
            /// <summary>
            /// 
            /// </summary>
            Broken_Telescope = 20563,
            /// <summary>
            /// 
            /// </summary>
            Space_Food = 20564,
            /// <summary>
            /// 
            /// </summary>
            Punctured_PCB = 20565,
            /// <summary>
            /// 
            /// </summary>
            Dead_Solar_Panel = 20566,
            /// <summary>
            /// 
            /// </summary>
            Warped_Wheel = 20567,
            /// <summary>
            /// 
            /// </summary>
            Luxury_Wheel = 20568,
            /// <summary>
            /// 
            /// </summary>
            Gold_Earrings = 20569,
            /// <summary>
            /// 
            /// </summary>
            Damascene_Cane = 20570,
            /// <summary>
            /// 
            /// </summary>
            Silver_Monocle = 20571,
            /// <summary>
            /// 
            /// </summary>
            Ivory_Dice = 20572,
            /// <summary>
            /// 
            /// </summary>
            Dealer_Ring = 20573,
            /// <summary>
            /// 
            /// </summary>
            Magician_Bowtie = 20574,
            /// <summary>
            /// 
            /// </summary>
            Pro_Dart = 20575,
            /// <summary>
            /// 
            /// </summary>
            Card_Shuffler = 20576,
            /// <summary>
            /// 
            /// </summary>
            Dice_Shaker = 20577,
            /// <summary>
            /// 
            /// </summary>
            Gray_Cufflinks = 20578,
            /// <summary>
            /// 
            /// </summary>
            Faded_Silk_Hat = 20579,
            /// <summary>
            /// 
            /// </summary>
            Smoked_Cigar = 20580,
            /// <summary>
            /// 
            /// </summary>
            Incomplete_Deck = 20581,
            /// <summary>
            /// 
            /// </summary>
            Coral_Pendant = 20582,
            /// <summary>
            /// 
            /// </summary>
            Pearl_Necklace = 20583,
            /// <summary>
            /// 
            /// </summary>
            Ebony_Box = 20584,
            /// <summary>
            /// 
            /// </summary>
            Marble_Chessboard = 20585,
            /// <summary>
            /// 
            /// </summary>
            Tortoise_Hairpin = 20586,
            /// <summary>
            /// 
            /// </summary>
            Cameo_Brooch = 20587,
            /// <summary>
            /// 
            /// </summary>
            Raden_Plate = 20588,
            /// <summary>
            /// 
            /// </summary>
            Peacock_Fan = 20589,
            /// <summary>
            /// 
            /// </summary>
            Bronze_Compass = 20590,
            /// <summary>
            /// 
            /// </summary>
            Brass_Pocket_Watch = 20591,
            /// <summary>
            /// 
            /// </summary>
            Music_Box = 20592,
            /// <summary>
            /// 
            /// </summary>
            Old_Kaleidoscope = 20593,
            /// <summary>
            /// 
            /// </summary>
            Mirror_Ball = 20594,
            /// <summary>
            /// 
            /// </summary>
            Masquerade_Mask = 20595,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20596 = 20596,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20597 = 20597,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20598 = 20598,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20599 = 20599,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20600 = 20600,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20601 = 20601,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20602 = 20602,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20603 = 20603,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20604 = 20604,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20605 = 20605,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20606 = 20606,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20607 = 20607,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20608 = 20608,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20609 = 20609,
            /// <summary>
            /// 
            /// </summary>
            Huge_Gold_Lump = 20610,
            /// <summary>
            /// 
            /// </summary>
            Large_Gold_Lump = 20611,
            /// <summary>
            /// 
            /// </summary>
            Small_Gold_Lump = 20612,
            /// <summary>
            /// 
            /// </summary>
            Grooved_Silver = 20613,
            /// <summary>
            /// 
            /// </summary>
            Hole_Silver = 20614,
            /// <summary>
            /// 
            /// </summary>
            Thin_Silver = 20615,
            /// <summary>
            /// 
            /// </summary>
            Grooved_Copper = 20616,
            /// <summary>
            /// 
            /// </summary>
            Hole_Copper = 20617,
            /// <summary>
            /// 
            /// </summary>
            Thin_Copper = 20618,
            /// <summary>
            /// 
            /// </summary>
            Onyx = 20619,
            /// <summary>
            /// 
            /// </summary>
            Pearl = 20620,
            /// <summary>
            /// 
            /// </summary>
            Amethyst = 20621,
            /// <summary>
            /// 
            /// </summary>
            Turquoise = 20622,
            /// <summary>
            /// 
            /// </summary>
            Opal = 20623,
            /// <summary>
            /// 
            /// </summary>
            Topaz = 20624,
            /// <summary>
            /// 
            /// </summary>
            Garnet = 20625,
            /// <summary>
            /// 
            /// </summary>
            Aquamarine = 20626,
            /// <summary>
            /// 
            /// </summary>
            Ruby = 20627,
            /// <summary>
            /// 
            /// </summary>
            Emerald = 20628,
            /// <summary>
            /// 
            /// </summary>
            Sapphire = 20629,
            /// <summary>
            /// 
            /// </summary>
            Diamond = 20630,
            /// <summary>
            /// 
            /// </summary>
            Jade = 20631,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20632 = 20632,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20633 = 20633,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20634 = 20634,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20635 = 20635,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20636 = 20636,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20637 = 20637,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20638 = 20638,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20639 = 20639,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20640 = 20640,
            /// <summary>
            /// 
            /// </summary>
            Platinum = 20641,
            /// <summary>
            /// 
            /// </summary>
            Dead_Surgical_Light = 20642,
            /// <summary>
            /// 
            /// </summary>
            Loose_Magnetic_Tape = 20643,
            /// <summary>
            /// 
            /// </summary>
            Tangled_USB_Cord = 20644,
            /// <summary>
            /// 
            /// </summary>
            Misprinted_Poster = 20645,
            /// <summary>
            /// 
            /// </summary>
            Voice_Recorder = 20646,
            /// <summary>
            /// 
            /// </summary>
            Laser_Pointer = 20647,
            /// <summary>
            /// 
            /// </summary>
            Voltage_Converter = 20648,
            /// <summary>
            /// 
            /// </summary>
            Broken_Meter_Panel = 20649,
            /// <summary>
            /// 
            /// </summary>
            Distorted_Lens = 20650,
            /// <summary>
            /// 
            /// </summary>
            Old_Projector = 20651,
            /// <summary>
            /// 
            /// </summary>
            Mini_Sound_Sensor = 20652,
            /// <summary>
            /// 
            /// </summary>
            Broken_Thermostat = 20653,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20654 = 20654,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20655 = 20655,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20656 = 20656,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20657 = 20657,
            /// <summary>
            /// 
            /// </summary>
            Silent_Horn = 20658,
            /// <summary>
            /// 
            /// </summary>
            Ripped_Uniform_Cap = 20659,
            /// <summary>
            /// 
            /// </summary>
            Broken_Baton = 20660,
            /// <summary>
            /// 
            /// </summary>
            Broken_Handcuffs = 20661,
            /// <summary>
            /// 
            /// </summary>
            Lustrous_Iron_Ball = 20662,
            /// <summary>
            /// 
            /// </summary>
            Tidy_Prison_Uniform = 20663,
            /// <summary>
            /// 
            /// </summary>
            Prison_Officer_Badge = 20664,
            /// <summary>
            /// 
            /// </summary>
            Hi_Fi_Megaphone = 20665,
            /// <summary>
            /// 
            /// </summary>
            Sharp_Barbed_Wire = 20666,
            /// <summary>
            /// 
            /// </summary>
            Gold_Emblem = 20667,
            /// <summary>
            /// 
            /// </summary>
            Golden_Cap_Badge = 20668,
            /// <summary>
            /// 
            /// </summary>
            Silver_Arm_Band = 20669,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20670 = 20670,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20671 = 20671,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20672 = 20672,
            /// <summary>
            /// 
            /// </summary>
            Copper_Lump = 20673,
            /// <summary>
            /// 
            /// </summary>
            Copper_Chain = 20674,
            /// <summary>
            /// 
            /// </summary>
            Copper_Hand = 20675,
            /// <summary>
            /// 
            /// </summary>
            Copper_Heart = 20676,
            /// <summary>
            /// 
            /// </summary>
            Copper_Star = 20677,
            /// <summary>
            /// 
            /// </summary>
            Copper_Moon = 20678,
            /// <summary>
            /// 
            /// </summary>
            Copper_Mist = 20679,
            /// <summary>
            /// 
            /// </summary>
            Silver_Lump = 20680,
            /// <summary>
            /// 
            /// </summary>
            Silver_Chain = 20681,
            /// <summary>
            /// 
            /// </summary>
            Silver_Hand = 20682,
            /// <summary>
            /// 
            /// </summary>
            Silver_Heart = 20683,
            /// <summary>
            /// 
            /// </summary>
            Silver_Star = 20684,
            /// <summary>
            /// 
            /// </summary>
            Silver_Moon = 20685,
            /// <summary>
            /// 
            /// </summary>
            Silver_Mist = 20686,
            /// <summary>
            /// 
            /// </summary>
            Gold_Lump = 20687,
            /// <summary>
            /// 
            /// </summary>
            Gold_Chain = 20688,
            /// <summary>
            /// 
            /// </summary>
            Gold_Hand = 20689,
            /// <summary>
            /// 
            /// </summary>
            Gold_Heart = 20690,
            /// <summary>
            /// 
            /// </summary>
            Gold_Star = 20691,
            /// <summary>
            /// 
            /// </summary>
            Gold_Moon = 20692,
            /// <summary>
            /// 
            /// </summary>
            Gold_Mist = 20693,
            /// <summary>
            /// 
            /// </summary>
            Platinum_Lump = 20694,
            /// <summary>
            /// 
            /// </summary>
            Diamond_Lump = 20695,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20696 = 20696,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20697 = 20697,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20698 = 20698,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20699 = 20699,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20700 = 20700,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20701 = 20701,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20702 = 20702,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20703 = 20703,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20704 = 20704,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20705 = 20705,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20706 = 20706,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20707 = 20707,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20708 = 20708,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20709 = 20709,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20710 = 20710,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20711 = 20711,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20712 = 20712,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20713 = 20713,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20714 = 20714,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20715 = 20715,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20716 = 20716,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20717 = 20717,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20718 = 20718,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20719 = 20719,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20720 = 20720,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20721 = 20721,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20722 = 20722,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20723 = 20723,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20724 = 20724,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20725 = 20725,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20726 = 20726,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20727 = 20727,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20728 = 20728,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20729 = 20729,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20730 = 20730,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20731 = 20731,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20732 = 20732,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20733 = 20733,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20734 = 20734,
            /// <summary>
            /// 
            /// </summary>
            RESERVE_20735 = 20735,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card = 24576,
            /// <summary>
            /// 
            /// </summary>
            Agi_Card = 24577,
            /// <summary>
            /// 
            /// </summary>
            Agilao_Card = 24578,
            /// <summary>
            /// 
            /// </summary>
            Agidyne_Card = 24579,
            /// <summary>
            /// 
            /// </summary>
            Maragi_Card = 24580,
            /// <summary>
            /// 
            /// </summary>
            Maragion_Card = 24581,
            /// <summary>
            /// 
            /// </summary>
            Maragidyne_Card = 24582,
            /// <summary>
            /// 
            /// </summary>
            Bufu_Card = 24583,
            /// <summary>
            /// 
            /// </summary>
            Bufula_Card = 24584,
            /// <summary>
            /// 
            /// </summary>
            Bufudyne_Card = 24585,
            /// <summary>
            /// 
            /// </summary>
            Mabufu_Card = 24586,
            /// <summary>
            /// 
            /// </summary>
            Mabufula_Card = 24587,
            /// <summary>
            /// 
            /// </summary>
            Mabufudyne_Card = 24588,
            /// <summary>
            /// 
            /// </summary>
            Garu_Card = 24589,
            /// <summary>
            /// 
            /// </summary>
            Garula_Card = 24590,
            /// <summary>
            /// 
            /// </summary>
            Garudyne_Card = 24591,
            /// <summary>
            /// 
            /// </summary>
            Magaru_Card = 24592,
            /// <summary>
            /// 
            /// </summary>
            Magarula_Card = 24593,
            /// <summary>
            /// 
            /// </summary>
            Magarudyne_Card = 24594,
            /// <summary>
            /// 
            /// </summary>
            Zio_Card = 24595,
            /// <summary>
            /// 
            /// </summary>
            Zionga_Card = 24596,
            /// <summary>
            /// 
            /// </summary>
            Ziodyne_Card = 24597,
            /// <summary>
            /// 
            /// </summary>
            Mazio_Card = 24598,
            /// <summary>
            /// 
            /// </summary>
            Mazionga_Card = 24599,
            /// <summary>
            /// 
            /// </summary>
            Maziodyne_Card = 24600,
            /// <summary>
            /// 
            /// </summary>
            Hama_Card = 24601,
            /// <summary>
            /// 
            /// </summary>
            Hamaon_Card = 24602,
            /// <summary>
            /// 
            /// </summary>
            Mahama_Card = 24603,
            /// <summary>
            /// 
            /// </summary>
            Mahamaon_Card = 24604,
            /// <summary>
            /// 
            /// </summary>
            Kouha_Card = 24605,
            /// <summary>
            /// 
            /// </summary>
            Kouga_Card = 24606,
            /// <summary>
            /// 
            /// </summary>
            Kougaon_Card = 24607,
            /// <summary>
            /// 
            /// </summary>
            Makouha_Card = 24608,
            /// <summary>
            /// 
            /// </summary>
            Makouga_Card = 24609,
            /// <summary>
            /// 
            /// </summary>
            Makougaon_Card = 24610,
            /// <summary>
            /// 
            /// </summary>
            Mudo_Card = 24611,
            /// <summary>
            /// 
            /// </summary>
            Mudoon_Card = 24612,
            /// <summary>
            /// 
            /// </summary>
            Mamudo_Card = 24613,
            /// <summary>
            /// 
            /// </summary>
            Mamudoon_Card = 24614,
            /// <summary>
            /// 
            /// </summary>
            Eiha_Card = 24615,
            /// <summary>
            /// 
            /// </summary>
            Eiga_Card = 24616,
            /// <summary>
            /// 
            /// </summary>
            Eigaon_Card = 24617,
            /// <summary>
            /// 
            /// </summary>
            Maeiha_Card = 24618,
            /// <summary>
            /// 
            /// </summary>
            Maeiga_Card = 24619,
            /// <summary>
            /// 
            /// </summary>
            Maeigaon_Card = 24620,
            /// <summary>
            /// 
            /// </summary>
            Megido_Card = 24621,
            /// <summary>
            /// 
            /// </summary>
            Megidola_Card = 24622,
            /// <summary>
            /// 
            /// </summary>
            Megidolaon_Card = 24623,
            /// <summary>
            /// 
            /// </summary>
            Frei_Card = 24624,
            /// <summary>
            /// 
            /// </summary>
            Freila_Card = 24625,
            /// <summary>
            /// 
            /// </summary>
            Freidyne_Card = 24626,
            /// <summary>
            /// 
            /// </summary>
            Mafrei_Card = 24627,
            /// <summary>
            /// 
            /// </summary>
            Mafreila_Card = 24628,
            /// <summary>
            /// 
            /// </summary>
            Mafreidyne_Card = 24629,
            /// <summary>
            /// 
            /// </summary>
            Dazzler_Card = 24630,
            /// <summary>
            /// 
            /// </summary>
            Nocturnal_Flash_Card = 24631,
            /// <summary>
            /// 
            /// </summary>
            Pulinpa_Card = 24632,
            /// <summary>
            /// 
            /// </summary>
            Tentarafoo_Card = 24633,
            /// <summary>
            /// 
            /// </summary>
            Evil_Touch_Card = 24634,
            /// <summary>
            /// 
            /// </summary>
            Evil_Smile_Card = 24635,
            /// <summary>
            /// 
            /// </summary>
            Makajama_Card = 24636,
            /// <summary>
            /// 
            /// </summary>
            Makajamaon_Card = 24637,
            /// <summary>
            /// 
            /// </summary>
            Famines_Breath_Card = 24638,
            /// <summary>
            /// 
            /// </summary>
            Famines_Scream_Card = 24639,
            /// <summary>
            /// 
            /// </summary>
            Dormina_Card = 24640,
            /// <summary>
            /// 
            /// </summary>
            Lullaby_Card = 24641,
            /// <summary>
            /// 
            /// </summary>
            Taunt_Card = 24642,
            /// <summary>
            /// 
            /// </summary>
            Wage_War_Card = 24643,
            /// <summary>
            /// 
            /// </summary>
            Ominous_Words_Card = 24644,
            /// <summary>
            /// 
            /// </summary>
            Abysmal_Surge_Card = 24645,
            /// <summary>
            /// 
            /// </summary>
            Marin_Karin_Card = 24646,
            /// <summary>
            /// 
            /// </summary>
            Brain_Jack_Card = 24647,
            /// <summary>
            /// 
            /// </summary>
            Trapped_Rat_Card = 24648,
            /// <summary>
            /// 
            /// </summary>
            Self_destruct_Card = 24649,
            /// <summary>
            /// 
            /// </summary>
            Self_destruct_Card_24650 = 24650,
            /// <summary>
            /// 
            /// </summary>
            Self_destruct_Card_24651 = 24651,
            /// <summary>
            /// 
            /// </summary>
            Life_Drain_Card = 24652,
            /// <summary>
            /// 
            /// </summary>
            Spirit_Drain_Card = 24653,
            /// <summary>
            /// 
            /// </summary>
            Life_Leech_Card = 24654,
            /// <summary>
            /// 
            /// </summary>
            Spirit_Leech_Card = 24655,
            /// <summary>
            /// 
            /// </summary>
            Foul_Breath_Card = 24656,
            /// <summary>
            /// 
            /// </summary>
            Stagnant_Air_Card = 24657,
            /// <summary>
            /// 
            /// </summary>
            Ghastly_Wail_Card = 24658,
            /// <summary>
            /// 
            /// </summary>
            Inferno_Card = 24659,
            /// <summary>
            /// 
            /// </summary>
            Blazing_Hell_Card = 24660,
            /// <summary>
            /// 
            /// </summary>
            Diamond_Dust_Card = 24661,
            /// <summary>
            /// 
            /// </summary>
            Ice_Age_Card = 24662,
            /// <summary>
            /// 
            /// </summary>
            Panta_Rhei_Card = 24663,
            /// <summary>
            /// 
            /// </summary>
            Vacuum_Wave_Card = 24664,
            /// <summary>
            /// 
            /// </summary>
            Thunder_Reign_Card = 24665,
            /// <summary>
            /// 
            /// </summary>
            Wild_Thunder_Card = 24666,
            /// <summary>
            /// 
            /// </summary>
            Divine_Judgment_Card = 24667,
            /// <summary>
            /// 
            /// </summary>
            Samsara_Card = 24668,
            /// <summary>
            /// 
            /// </summary>
            Demonic_Decree_Card = 24669,
            /// <summary>
            /// 
            /// </summary>
            Die_For_Me_Card = 24670,
            /// <summary>
            /// 
            /// </summary>
            Atomic_Flare_Card = 24671,
            /// <summary>
            /// 
            /// </summary>
            Cosmic_Flare_Card = 24672,
            /// <summary>
            /// 
            /// </summary>
            Black_Viper_Card = 24673,
            /// <summary>
            /// 
            /// </summary>
            Morning_Star_Card = 24674,
            /// <summary>
            /// 
            /// </summary>
            Psi_Card = 24675,
            /// <summary>
            /// 
            /// </summary>
            Psio_Card = 24676,
            /// <summary>
            /// 
            /// </summary>
            Psiodyne_Card = 24677,
            /// <summary>
            /// 
            /// </summary>
            Mapsi_Card = 24678,
            /// <summary>
            /// 
            /// </summary>
            Mapsio_Card = 24679,
            /// <summary>
            /// 
            /// </summary>
            Mapsiodyne_Card = 24680,
            /// <summary>
            /// 
            /// </summary>
            Psycho_Force_Card = 24681,
            /// <summary>
            /// 
            /// </summary>
            Psycho_Blast_Card = 24682,
            /// <summary>
            /// 
            /// </summary>
            Lunge_Card = 24683,
            /// <summary>
            /// 
            /// </summary>
            Assault_Dive_Card = 24684,
            /// <summary>
            /// 
            /// </summary>
            Megaton_Raid_Card = 24685,
            /// <summary>
            /// 
            /// </summary>
            Gods_Hand_Card = 24686,
            /// <summary>
            /// 
            /// </summary>
            Lucky_Punch_Card = 24687,
            /// <summary>
            /// 
            /// </summary>
            Miracle_Punch_Card = 24688,
            /// <summary>
            /// 
            /// </summary>
            Cleave_Card = 24689,
            /// <summary>
            /// 
            /// </summary>
            Giant_Slice_Card = 24690,
            /// <summary>
            /// 
            /// </summary>
            Brave_Blade_Card = 24691,
            /// <summary>
            /// 
            /// </summary>
            Sword_Dance_Card = 24692,
            /// <summary>
            /// 
            /// </summary>
            Hassou_Tobi_Card = 24693,
            /// <summary>
            /// 
            /// </summary>
            Ayamur_Card = 24694,
            /// <summary>
            /// 
            /// </summary>
            Cornered_Fang_Card = 24695,
            /// <summary>
            /// 
            /// </summary>
            Rising_Slash_Card = 24696,
            /// <summary>
            /// 
            /// </summary>
            Deadly_Fury_Card = 24697,
            /// <summary>
            /// 
            /// </summary>
            Snap_Card = 24698,
            /// <summary>
            /// 
            /// </summary>
            Triple_Down_Card = 24699,
            /// <summary>
            /// 
            /// </summary>
            One_shot_Kill_Card = 24700,
            /// <summary>
            /// 
            /// </summary>
            Riot_Gun_Card = 24701,
            /// <summary>
            /// 
            /// </summary>
            Vajra_Blast_Card = 24702,
            /// <summary>
            /// 
            /// </summary>
            Vorpal_Blade_Card = 24703,
            /// <summary>
            /// 
            /// </summary>
            Vicious_Strike_Card = 24704,
            /// <summary>
            /// 
            /// </summary>
            Heat_Wave_Card = 24705,
            /// <summary>
            /// 
            /// </summary>
            Gigantomachia_Card = 24706,
            /// <summary>
            /// 
            /// </summary>
            Rampage_Card = 24707,
            /// <summary>
            /// 
            /// </summary>
            Swift_Strike_Card = 24708,
            /// <summary>
            /// 
            /// </summary>
            Deathbound_Card = 24709,
            /// <summary>
            /// 
            /// </summary>
            Agneyastra_Card = 24710,
            /// <summary>
            /// 
            /// </summary>
            Double_Fangs_Card = 24711,
            /// <summary>
            /// 
            /// </summary>
            Tempest_Slash_Card = 24712,
            /// <summary>
            /// 
            /// </summary>
            Myriad_Slashes_Card = 24713,
            /// <summary>
            /// 
            /// </summary>
            Sledgehammer_Card = 24714,
            /// <summary>
            /// 
            /// </summary>
            Skull_Cracker_Card = 24715,
            /// <summary>
            /// 
            /// </summary>
            Terror_Claw_Card = 24716,
            /// <summary>
            /// 
            /// </summary>
            Headbutt_Card = 24717,
            /// <summary>
            /// 
            /// </summary>
            Stomach_Blow_Card = 24718,
            /// <summary>
            /// 
            /// </summary>
            Dream_Needle_Card = 24719,
            /// <summary>
            /// 
            /// </summary>
            Hysterical_Slap_Card = 24720,
            /// <summary>
            /// 
            /// </summary>
            Negative_Pile_Card = 24721,
            /// <summary>
            /// 
            /// </summary>
            Brain_Shake_Card = 24722,
            /// <summary>
            /// 
            /// </summary>
            Flash_Bomb_Card = 24723,
            /// <summary>
            /// 
            /// </summary>
            Mind_Slice_Card = 24724,
            /// <summary>
            /// 
            /// </summary>
            Bloodbath_Card = 24725,
            /// <summary>
            /// 
            /// </summary>
            Memory_Blow_Card = 24726,
            /// <summary>
            /// 
            /// </summary>
            Insatiable_Strike_Card = 24727,
            /// <summary>
            /// 
            /// </summary>
            Dormin_Rush_Card = 24728,
            /// <summary>
            /// 
            /// </summary>
            Oni_Kagura_Card = 24729,
            /// <summary>
            /// 
            /// </summary>
            Bad_Beat_Card = 24730,
            /// <summary>
            /// 
            /// </summary>
            Brain_Buster_Card = 24731,
            /// <summary>
            /// 
            /// </summary>
            Dia_Card = 24732,
            /// <summary>
            /// 
            /// </summary>
            Diarama_Card = 24733,
            /// <summary>
            /// 
            /// </summary>
            Diarahan_Card = 24734,
            /// <summary>
            /// 
            /// </summary>
            Media_Card = 24735,
            /// <summary>
            /// 
            /// </summary>
            Mediarama_Card = 24736,
            /// <summary>
            /// 
            /// </summary>
            Mediarahan_Card = 24737,
            /// <summary>
            /// 
            /// </summary>
            Recarm_Card = 24738,
            /// <summary>
            /// 
            /// </summary>
            Samarecarm_Card = 24739,
            /// <summary>
            /// 
            /// </summary>
            Recarmdra_Card = 24740,
            /// <summary>
            /// 
            /// </summary>
            Amrita_Drop_Card = 24741,
            /// <summary>
            /// 
            /// </summary>
            Amrita_Shower_Card = 24742,
            /// <summary>
            /// 
            /// </summary>
            Mabaisudi_Card = 24743,
            /// <summary>
            /// 
            /// </summary>
            Salvation_Card = 24744,
            /// <summary>
            /// 
            /// </summary>
            Patra_Card = 24745,
            /// <summary>
            /// 
            /// </summary>
            Energy_Shower_Card = 24746,
            /// <summary>
            /// 
            /// </summary>
            Energy_Drop_Card = 24747,
            /// <summary>
            /// 
            /// </summary>
            Baisudi_Card = 24748,
            /// <summary>
            /// 
            /// </summary>
            Me_Patra_Card = 24749,
            /// <summary>
            /// 
            /// </summary>
            Tarukaja_Card = 24750,
            /// <summary>
            /// 
            /// </summary>
            Rakukaja_Card = 24751,
            /// <summary>
            /// 
            /// </summary>
            Sukukaja_Card = 24752,
            /// <summary>
            /// 
            /// </summary>
            Heat_Riser_Card = 24753,
            /// <summary>
            /// 
            /// </summary>
            Matarukaja_Card = 24754,
            /// <summary>
            /// 
            /// </summary>
            Marakukaja_Card = 24755,
            /// <summary>
            /// 
            /// </summary>
            Masukukaja_Card = 24756,
            /// <summary>
            /// 
            /// </summary>
            Thermopylae_Card = 24757,
            /// <summary>
            /// 
            /// </summary>
            Tarunda_Card = 24758,
            /// <summary>
            /// 
            /// </summary>
            Rakunda_Card = 24759,
            /// <summary>
            /// 
            /// </summary>
            Sukunda_Card = 24760,
            /// <summary>
            /// 
            /// </summary>
            Debilitate_Card = 24761,
            /// <summary>
            /// 
            /// </summary>
            Matarunda_Card = 24762,
            /// <summary>
            /// 
            /// </summary>
            Marakunda_Card = 24763,
            /// <summary>
            /// 
            /// </summary>
            Masukunda_Card = 24764,
            /// <summary>
            /// 
            /// </summary>
            Dekunda_Card = 24765,
            /// <summary>
            /// 
            /// </summary>
            Dekaja_Card = 24766,
            /// <summary>
            /// 
            /// </summary>
            Charge_Card = 24767,
            /// <summary>
            /// 
            /// </summary>
            Concentrate_Card = 24768,
            /// <summary>
            /// 
            /// </summary>
            Rebellion_Card = 24769,
            /// <summary>
            /// 
            /// </summary>
            Revolution_Card = 24770,
            /// <summary>
            /// 
            /// </summary>
            Tetrakarn_Card = 24771,
            /// <summary>
            /// 
            /// </summary>
            Makarakarn_Card = 24772,
            /// <summary>
            /// 
            /// </summary>
            Tetraja_Card = 24773,
            /// <summary>
            /// 
            /// </summary>
            Tetra_Break_Card = 24774,
            /// <summary>
            /// 
            /// </summary>
            Makara_Break_Card = 24775,
            /// <summary>
            /// 
            /// </summary>
            Fire_Wall_Card = 24776,
            /// <summary>
            /// 
            /// </summary>
            Ice_Wall_Card = 24777,
            /// <summary>
            /// 
            /// </summary>
            Elec_Wall_Card = 24778,
            /// <summary>
            /// 
            /// </summary>
            Wind_Wall_Card = 24779,
            /// <summary>
            /// 
            /// </summary>
            Fire_Break_Card = 24780,
            /// <summary>
            /// 
            /// </summary>
            Ice_Break_Card = 24781,
            /// <summary>
            /// 
            /// </summary>
            Wind_Break_Card = 24782,
            /// <summary>
            /// 
            /// </summary>
            Elec_Break_Card = 24783,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24784 = 24784,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24785 = 24785,
            /// <summary>
            /// 
            /// </summary>
            Nuke_Wall_Card = 24786,
            /// <summary>
            /// 
            /// </summary>
            Psy_Wall_Card = 24787,
            /// <summary>
            /// 
            /// </summary>
            Nuke_Break_Card = 24788,
            /// <summary>
            /// 
            /// </summary>
            Psy_Break_Card = 24789,
            /// <summary>
            /// 
            /// </summary>
            Counter_Card = 24790,
            /// <summary>
            /// 
            /// </summary>
            Counterstrike_Card = 24791,
            /// <summary>
            /// 
            /// </summary>
            High_Counter_Card = 24792,
            /// <summary>
            /// 
            /// </summary>
            Endure_Card = 24793,
            /// <summary>
            /// 
            /// </summary>
            Enduring_Soul_Card = 24794,
            /// <summary>
            /// 
            /// </summary>
            Dodge_Bless_Card = 24795,
            /// <summary>
            /// 
            /// </summary>
            Dodge_Curse_Card = 24796,
            /// <summary>
            /// 
            /// </summary>
            Survival_Trick_Card = 24797,
            /// <summary>
            /// 
            /// </summary>
            Dodge_Fire_Card = 24798,
            /// <summary>
            /// 
            /// </summary>
            Evade_Fire_Card = 24799,
            /// <summary>
            /// 
            /// </summary>
            Dodge_Ice_Card = 24800,
            /// <summary>
            /// 
            /// </summary>
            Evade_Ice_Card = 24801,
            /// <summary>
            /// 
            /// </summary>
            Dodge_Wind_Card = 24802,
            /// <summary>
            /// 
            /// </summary>
            Evade_Wind_Card = 24803,
            /// <summary>
            /// 
            /// </summary>
            Dodge_Elec_Card = 24804,
            /// <summary>
            /// 
            /// </summary>
            Evade_Elec_Card = 24805,
            /// <summary>
            /// 
            /// </summary>
            Dodge_Phys_Card = 24806,
            /// <summary>
            /// 
            /// </summary>
            Evade_Phys_Card = 24807,
            /// <summary>
            /// 
            /// </summary>
            Fire_Boost_Card = 24808,
            /// <summary>
            /// 
            /// </summary>
            Fire_Amp_Card = 24809,
            /// <summary>
            /// 
            /// </summary>
            Ice_Boost_Card = 24810,
            /// <summary>
            /// 
            /// </summary>
            Ice_Amp_Card = 24811,
            /// <summary>
            /// 
            /// </summary>
            Wind_Boost_Card = 24812,
            /// <summary>
            /// 
            /// </summary>
            Wind_Amp_Card = 24813,
            /// <summary>
            /// 
            /// </summary>
            Elec_Boost_Card = 24814,
            /// <summary>
            /// 
            /// </summary>
            Elec_Amp_Card = 24815,
            /// <summary>
            /// 
            /// </summary>
            Angelic_Grace_Card = 24816,
            /// <summary>
            /// 
            /// </summary>
            Divine_Grace_Card = 24817,
            /// <summary>
            /// 
            /// </summary>
            Regenerate_1_Card = 24818,
            /// <summary>
            /// 
            /// </summary>
            Regenerate_2_Card = 24819,
            /// <summary>
            /// 
            /// </summary>
            Regenerate_3_Card = 24820,
            /// <summary>
            /// 
            /// </summary>
            Invigorate_1_Card = 24821,
            /// <summary>
            /// 
            /// </summary>
            Invigorate_2_Card = 24822,
            /// <summary>
            /// 
            /// </summary>
            Invigorate_3_Card = 24823,
            /// <summary>
            /// 
            /// </summary>
            Attack_Master_Card = 24824,
            /// <summary>
            /// 
            /// </summary>
            Auto_Mataru_Card = 24825,
            /// <summary>
            /// 
            /// </summary>
            Defense_Master_Card = 24826,
            /// <summary>
            /// 
            /// </summary>
            Auto_Maraku_Card = 24827,
            /// <summary>
            /// 
            /// </summary>
            Speed_Master_Card = 24828,
            /// <summary>
            /// 
            /// </summary>
            Auto_Masuku_Card = 24829,
            /// <summary>
            /// 
            /// </summary>
            Fast_Heal_Card = 24830,
            /// <summary>
            /// 
            /// </summary>
            Insta_Heal_Card = 24831,
            /// <summary>
            /// 
            /// </summary>
            Arms_Master_Card = 24832,
            /// <summary>
            /// 
            /// </summary>
            Spell_Master_Card = 24833,
            /// <summary>
            /// 
            /// </summary>
            Sharp_Student_Card = 24834,
            /// <summary>
            /// 
            /// </summary>
            Apt_Pupil_Card = 24835,
            /// <summary>
            /// 
            /// </summary>
            Ali_Dance_Card = 24836,
            /// <summary>
            /// 
            /// </summary>
            Firm_Stance_Card = 24837,
            /// <summary>
            /// 
            /// </summary>
            Life_Aid_Card = 24838,
            /// <summary>
            /// 
            /// </summary>
            Victory_Cry_Card = 24839,
            /// <summary>
            /// 
            /// </summary>
            Growth_1_Card = 24840,
            /// <summary>
            /// 
            /// </summary>
            Growth_2_Card = 24841,
            /// <summary>
            /// 
            /// </summary>
            Growth_3_Card = 24842,
            /// <summary>
            /// 
            /// </summary>
            Unshaken_Will_Card = 24843,
            /// <summary>
            /// 
            /// </summary>
            Evade_Bless_Card = 24844,
            /// <summary>
            /// 
            /// </summary>
            Evade_Curse_Card = 24845,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24846 = 24846,
            /// <summary>
            /// 
            /// </summary>
            Resist_Fire_Card = 24847,
            /// <summary>
            /// 
            /// </summary>
            Null_Fire_Card = 24848,
            /// <summary>
            /// 
            /// </summary>
            Repel_Fire_Card = 24849,
            /// <summary>
            /// 
            /// </summary>
            Drain_Fire_Card = 24850,
            /// <summary>
            /// 
            /// </summary>
            Resist_Ice_Card = 24851,
            /// <summary>
            /// 
            /// </summary>
            Null_Ice_Card = 24852,
            /// <summary>
            /// 
            /// </summary>
            Repel_Ice_Card = 24853,
            /// <summary>
            /// 
            /// </summary>
            Drain_Ice_Card = 24854,
            /// <summary>
            /// 
            /// </summary>
            Resist_Wind_Card = 24855,
            /// <summary>
            /// 
            /// </summary>
            Null_Wind_Card = 24856,
            /// <summary>
            /// 
            /// </summary>
            Repel_Wind_Card = 24857,
            /// <summary>
            /// 
            /// </summary>
            Drain_Wind_Card = 24858,
            /// <summary>
            /// 
            /// </summary>
            Resist_Elec_Card = 24859,
            /// <summary>
            /// 
            /// </summary>
            Null_Elec_Card = 24860,
            /// <summary>
            /// 
            /// </summary>
            Repel_Elec_Card = 24861,
            /// <summary>
            /// 
            /// </summary>
            Drain_Elec_Card = 24862,
            /// <summary>
            /// 
            /// </summary>
            Resist_Bless_Card = 24863,
            /// <summary>
            /// 
            /// </summary>
            Null_Bless_Card = 24864,
            /// <summary>
            /// 
            /// </summary>
            Repel_Bless_Card = 24865,
            /// <summary>
            /// 
            /// </summary>
            Drain_Bless_Card = 24866,
            /// <summary>
            /// 
            /// </summary>
            Resist_Curse_Card = 24867,
            /// <summary>
            /// 
            /// </summary>
            Null_Curse_Card = 24868,
            /// <summary>
            /// 
            /// </summary>
            Repel_Curse_Card = 24869,
            /// <summary>
            /// 
            /// </summary>
            Drain_Curse_Card = 24870,
            /// <summary>
            /// 
            /// </summary>
            Resist_Phys_Card = 24871,
            /// <summary>
            /// 
            /// </summary>
            Null_Phys_Card = 24872,
            /// <summary>
            /// 
            /// </summary>
            Repel_Phys_Card = 24873,
            /// <summary>
            /// 
            /// </summary>
            Drain_Phys_Card = 24874,
            /// <summary>
            /// 
            /// </summary>
            Ailment_Boost_Card = 24875,
            /// <summary>
            /// 
            /// </summary>
            Hama_Boost_Card = 24876,
            /// <summary>
            /// 
            /// </summary>
            Mudo_Boost_Card = 24877,
            /// <summary>
            /// 
            /// </summary>
            Dizzy_Boost_Card = 24878,
            /// <summary>
            /// 
            /// </summary>
            Confuse_Boost_Card = 24879,
            /// <summary>
            /// 
            /// </summary>
            Fear_Boost_Card = 24880,
            /// <summary>
            /// 
            /// </summary>
            Forget_Boost_Card = 24881,
            /// <summary>
            /// 
            /// </summary>
            Sleep_Boost_Card = 24882,
            /// <summary>
            /// 
            /// </summary>
            Rage_Boost_Card = 24883,
            /// <summary>
            /// 
            /// </summary>
            Despair_Boost_Card = 24884,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24885 = 24885,
            /// <summary>
            /// 
            /// </summary>
            Brainwash_Boost_Card = 24886,
            /// <summary>
            /// 
            /// </summary>
            Resist_Dizzy_Card = 24887,
            /// <summary>
            /// 
            /// </summary>
            Resist_Confuse_Card = 24888,
            /// <summary>
            /// 
            /// </summary>
            Resist_Fear_Card = 24889,
            /// <summary>
            /// 
            /// </summary>
            Resist_Forget_Card = 24890,
            /// <summary>
            /// 
            /// </summary>
            Resist_Sleep_Card = 24891,
            /// <summary>
            /// 
            /// </summary>
            Resist_Rage_Card = 24892,
            /// <summary>
            /// 
            /// </summary>
            Resist_Despair_Card = 24893,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24894 = 24894,
            /// <summary>
            /// 
            /// </summary>
            Resist_Brainwash_Card = 24895,
            /// <summary>
            /// 
            /// </summary>
            Null_Dizzy_Card = 24896,
            /// <summary>
            /// 
            /// </summary>
            Null_Confuse_Card = 24897,
            /// <summary>
            /// 
            /// </summary>
            Null_Fear_Card = 24898,
            /// <summary>
            /// 
            /// </summary>
            Null_Forget_Card = 24899,
            /// <summary>
            /// 
            /// </summary>
            Null_Sleep_Card = 24900,
            /// <summary>
            /// 
            /// </summary>
            Null_Rage_Card = 24901,
            /// <summary>
            /// 
            /// </summary>
            Null_Despair_Card = 24902,
            /// <summary>
            /// 
            /// </summary>
            Null_Brainwash_Card = 24903,
            /// <summary>
            /// 
            /// </summary>
            Burn_Boost_Card = 24904,
            /// <summary>
            /// 
            /// </summary>
            Freeze_Boost_Card = 24905,
            /// <summary>
            /// 
            /// </summary>
            Shock_Boost_Card = 24906,
            /// <summary>
            /// 
            /// </summary>
            Fortified_Moxy_Card = 24907,
            /// <summary>
            /// 
            /// </summary>
            Adverse_Resolve_Card = 24908,
            /// <summary>
            /// 
            /// </summary>
            Last_Stand_Card = 24909,
            /// <summary>
            /// 
            /// </summary>
            Heat_Up_Card = 24910,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24911 = 24911,
            /// <summary>
            /// 
            /// </summary>
            Touch_n_Go_Card = 24912,
            /// <summary>
            /// 
            /// </summary>
            Climate_Decorum_Card = 24913,
            /// <summary>
            /// 
            /// </summary>
            Ambient_Aid_Card = 24914,
            /// <summary>
            /// 
            /// </summary>
            Snipe_Card = 24915,
            /// <summary>
            /// 
            /// </summary>
            Cripple_Card = 24916,
            /// <summary>
            /// 
            /// </summary>
            Trigger_Happy_Card = 24917,
            /// <summary>
            /// 
            /// </summary>
            Resist_Nuke_Card = 24918,
            /// <summary>
            /// 
            /// </summary>
            Null_Nuke_Card = 24919,
            /// <summary>
            /// 
            /// </summary>
            Repel_Nuke_Card = 24920,
            /// <summary>
            /// 
            /// </summary>
            Drain_Nuke_Card = 24921,
            /// <summary>
            /// 
            /// </summary>
            Resist_Psy_Card = 24922,
            /// <summary>
            /// 
            /// </summary>
            Null_Psy_Card = 24923,
            /// <summary>
            /// 
            /// </summary>
            Repel_Psy_Card = 24924,
            /// <summary>
            /// 
            /// </summary>
            Drain_Psy_Card = 24925,
            /// <summary>
            /// 
            /// </summary>
            Nuke_Boost_Card = 24926,
            /// <summary>
            /// 
            /// </summary>
            Nuke_Amp_Card = 24927,
            /// <summary>
            /// 
            /// </summary>
            Psy_Boost_Card = 24928,
            /// <summary>
            /// 
            /// </summary>
            Psy_Amp_Card = 24929,
            /// <summary>
            /// 
            /// </summary>
            Dodge_Nuke_Card = 24930,
            /// <summary>
            /// 
            /// </summary>
            Evade_Nuke_Card = 24931,
            /// <summary>
            /// 
            /// </summary>
            Dodge_Psy_Card = 24932,
            /// <summary>
            /// 
            /// </summary>
            Evade_Psy_Card = 24933,
            /// <summary>
            /// 
            /// </summary>
            Bless_Boost_Card = 24934,
            /// <summary>
            /// 
            /// </summary>
            Bless_Amp_Card = 24935,
            /// <summary>
            /// 
            /// </summary>
            Curse_Boost_Card = 24936,
            /// <summary>
            /// 
            /// </summary>
            Curse_Amp_Card = 24937,
            /// <summary>
            /// 
            /// </summary>
            Magic_Ability_Card = 24938,
            /// <summary>
            /// 
            /// </summary>
            Fortify_Spirit_Card = 24939,
            /// <summary>
            /// 
            /// </summary>
            Almighty_Boost_Card = 24940,
            /// <summary>
            /// 
            /// </summary>
            Almighty_Amp_Card = 24941,
            /// <summary>
            /// 
            /// </summary>
            Zenith_Defense_Card = 24942,
            /// <summary>
            /// 
            /// </summary>
            Soul_Chain_Card = 24943,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24944 = 24944,
            /// <summary>
            /// 
            /// </summary>
            Kill_Rush_Card = 24945,
            /// <summary>
            /// 
            /// </summary>
            Gatling_Blow_Card = 24946,
            /// <summary>
            /// 
            /// </summary>
            Double_Shot_Card = 24947,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24948 = 24948,
            /// <summary>
            /// 
            /// </summary>
            Death_Scythe_Card = 24949,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24950 = 24950,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24951 = 24951,
            /// <summary>
            /// 
            /// </summary>
            Taunting_Aura_Card = 24952,
            /// <summary>
            /// 
            /// </summary>
            Concealment_Card = 24953,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24954 = 24954,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24955 = 24955,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24956 = 24956,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24957 = 24957,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24958 = 24958,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24959 = 24959,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24960 = 24960,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Card_24961 = 24961,
            /// <summary>
            /// 
            /// </summary>
            Blank_Card_Card = 24962,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Critical_Atk_Up_Card = 24963,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Ailment_Dmg_Up_Plus_Card = 24964,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Insta_kill_SP_low_Card = 24965,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Insta_kill_SP_med_Card = 24966,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Insta_kill_SP_high_Card = 24967,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Technical_Up_Card = 24968,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Technical_Up_Plus_Card = 24969,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Low_HP_Atk_Up_Card = 24970,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Low_HP_Atk_Up_Plus_Card = 24971,
            /// <summary>
            /// 
            /// </summary>
            BLANK_WEAK_Hit_Up_Card = 24972,
            /// <summary>
            /// 
            /// </summary>
            BLANK_WEAK_Hit_Up_Plus_Card = 24973,
            /// <summary>
            /// 
            /// </summary>
            BLANK_Null_Insta_kill_Card = 24974,
            /// <summary>
            /// 
            /// </summary>
            BLANK_HP_Cost__10_Percent_Card = 24975,
            /// <summary>
            /// 
            /// </summary>
            BLANK_HP_Cost__25_Percent_Card = 24976,
            /// <summary>
            /// 
            /// </summary>
            Starter_Clothes = 28672,
            /// <summary>
            /// Useable by All
            /// </summary>
            Shujin_Uniform = 28673,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28674 = 28674,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28675 = 28675,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28676 = 28676,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28677 = 28677,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28678 = 28678,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28679 = 28679,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28680 = 28680,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28681 = 28681,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28682 = 28682,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28683 = 28683,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28684 = 28684,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Dark_Suit = 28685,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28686 = 28686,
            /// <summary>
            /// Useable by All
            /// </summary>
            BLANK_28687 = 28687,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Phantom_Suit = 28688,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Pirate_Armor = 28689,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Morgana_Classic = 28690,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Red_Latex_Suit = 28691,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Outlaws_Attire = 28692,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Metal_Rider = 28693,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Musketeer_Suit = 28694,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Cyber_Gear = 28695,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Prince_Suit = 28696,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Black_Leotard = 28697,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Summer_Uniform = 28698,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Summer_Uniform_28699 = 28699,
            /// <summary>
            /// 
            /// </summary>
            Summer_Uniform_28700 = 28700,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Summer_Uniform_28701 = 28701,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Summer_Uniform_28702 = 28702,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Summer_Uniform_28703 = 28703,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Summer_Uniform_28704 = 28704,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Summer_Uniform_28705 = 28705,
            /// <summary>
            /// 
            /// </summary>
            Summer_Uniform_28706 = 28706,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Summer_Uniform_28707 = 28707,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Winter_Uniform = 28708,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Winter_Uniform_28709 = 28709,
            /// <summary>
            /// 
            /// </summary>
            Winter_Uniform_28710 = 28710,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Winter_Uniform_28711 = 28711,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Winter_Uniform_28712 = 28712,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Winter_Uniform_28713 = 28713,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Winter_Uniform_28714 = 28714,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Winter_Uniform_28715 = 28715,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Winter_Uniform_28716 = 28716,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Winter_Uniform_28717 = 28717,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Summer_Clothes = 28718,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Summer_Clothes_28719 = 28719,
            /// <summary>
            /// 
            /// </summary>
            Summer_Clothes_28720 = 28720,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Summer_Clothes_28721 = 28721,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Summer_Clothes_28722 = 28722,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Summer_Clothes_28723 = 28723,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Summer_Clothes_28724 = 28724,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Summer_Clothes_28725 = 28725,
            /// <summary>
            /// 
            /// </summary>
            Summer_Clothes_28726 = 28726,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Summer_Clothes_28727 = 28727,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Winter_Clothes = 28728,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Winter_Clothes_28729 = 28729,
            /// <summary>
            /// 
            /// </summary>
            Winter_Clothes_28730 = 28730,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Winter_Clothes_28731 = 28731,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Winter_Clothes_28732 = 28732,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Winter_Clothes_28733 = 28733,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Winter_Clothes_28734 = 28734,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Winter_Clothes_28735 = 28735,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Winter_Clothes_28736 = 28736,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Winter_Clothes_28737 = 28737,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Tracksuit = 28738,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Tracksuit_28739 = 28739,
            /// <summary>
            /// 
            /// </summary>
            Tracksuit_28740 = 28740,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Tracksuit_28741 = 28741,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Tracksuit_28742 = 28742,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Tracksuit_28743 = 28743,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Tracksuit_28744 = 28744,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Tracksuit_28745 = 28745,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Tracksuit_28746 = 28746,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Tracksuit_28747 = 28747,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Swimsuit = 28748,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Swimsuit_28749 = 28749,
            /// <summary>
            /// 
            /// </summary>
            Swimsuit_28750 = 28750,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Swimsuit_28751 = 28751,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Swimsuit_28752 = 28752,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Swimsuit_28753 = 28753,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Swimsuit_28754 = 28754,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Swimsuit_28755 = 28755,
            /// <summary>
            /// 
            /// </summary>
            Swimsuit_28756 = 28756,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Swimsuit_28757 = 28757,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Loungewear = 28758,
            /// <summary>
            /// 
            /// </summary>
            Loungewear_28759 = 28759,
            /// <summary>
            /// 
            /// </summary>
            Loungewear_28760 = 28760,
            /// <summary>
            /// 
            /// </summary>
            Loungewear_28761 = 28761,
            /// <summary>
            /// 
            /// </summary>
            Loungewear_28762 = 28762,
            /// <summary>
            /// 
            /// </summary>
            Loungewear_28763 = 28763,
            /// <summary>
            /// 
            /// </summary>
            Loungewear_28764 = 28764,
            /// <summary>
            /// 
            /// </summary>
            Loungewear_28765 = 28765,
            /// <summary>
            /// 
            /// </summary>
            Loungewear_28766 = 28766,
            /// <summary>
            /// 
            /// </summary>
            Loungewear_28767 = 28767,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Gekkoukan_High = 28768,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Gekkoukan_High_28769 = 28769,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Aigis_Costume = 28770,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Gekkoukan_High_28771 = 28771,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Gekkoukan_High_28772 = 28772,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Gekkoukan_High_28773 = 28773,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Gekkoukan_High_28774 = 28774,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Gekkoukan_High_28775 = 28775,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Gekkoukan_High_28776 = 28776,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Gekkoukan_High_28777 = 28777,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Yasogami_High = 28778,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Yasogami_High_28779 = 28779,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Teddie_Costume = 28780,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Yasogami_High_28781 = 28781,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Yasogami_High_28782 = 28782,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Yasogami_High_28783 = 28783,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Yasogami_High_28784 = 28784,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Yasogami_High_28785 = 28785,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Yasogami_High_28786 = 28786,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Yasogami_High_28787 = 28787,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            St_Hermelin_High = 28788,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            St_Hermelin_High_28789 = 28789,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Trish_Costume_v1 = 28790,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            St_Hermelin_High_28791 = 28791,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            St_Hermelin_High_28792 = 28792,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            St_Hermelin_High_28793 = 28793,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            St_Hermelin_High_28794 = 28794,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            St_Hermelin_High_28795 = 28795,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            St_Hermelin_High_28796 = 28796,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            St_Hermelin_High_28797 = 28797,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Seven_Sisters_High = 28798,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Seven_Sisters_High_28799 = 28799,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Trish_Costume_v2 = 28800,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Seven_Sisters_High_28801 = 28801,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Seven_Sisters_High_28802 = 28802,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Seven_Sisters_High_28803 = 28803,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Seven_Sisters_High_28804 = 28804,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Seven_Sisters_High_28805 = 28805,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Kasugayama_High = 28806,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Seven_Sisters_High_28807 = 28807,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Vincents_Outfit = 28808,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Orlandos_Fashion = 28809,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Stray_Sheeps_Suit = 28810,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Catherines_Cami = 28811,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Johnnys_Coat = 28812,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Katherines_Outfit = 28813,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Ericas_Uniform = 28814,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Tobys_Overalls = 28815,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Bosss_Suit = 28816,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Rins_One_Piece = 28817,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Karukozaka_High = 28818,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Karukozaka_High_28819 = 28819,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Karukozaka_High_28820 = 28820,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Karukozaka_High_28821 = 28821,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Karukozaka_High_28822 = 28822,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Karukozaka_High_28823 = 28823,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Karukozaka_High_28824 = 28824,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Karukozaka_High_28825 = 28825,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Hazamas_Uniform = 28826,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Karukozaka_High_28827 = 28827,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Butler_Suit = 28828,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Butler_Suit_28829 = 28829,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Maid_Uniform = 28830,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Maid_Uniform_28831 = 28831,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Butler_Suit_28832 = 28832,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Maid_Uniform_28833 = 28833,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Maid_Uniform_28834 = 28834,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Maid_Uniform_28835 = 28835,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Butler_Suit_28836 = 28836,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Maid_Uniform_28837 = 28837,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Christmas_Outfit = 28838,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Christmas_Outfit_28839 = 28839,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Christmas_Outfit_28840 = 28840,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Christmas_Outfit_28841 = 28841,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Christmas_Outfit_28842 = 28842,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Christmas_Outfit_28843 = 28843,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Christmas_Outfit_28844 = 28844,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Christmas_Outfit_28845 = 28845,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Christmas_Outfit_28846 = 28846,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Christmas_Outfit_28847 = 28847,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Dancewear = 28848,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Dancewear_28849 = 28849,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Dancewear_28850 = 28850,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Dancewear_28851 = 28851,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Dancewear_28852 = 28852,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Dancewear_28853 = 28853,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Dancewear_28854 = 28854,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Dancewear_28855 = 28855,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Dancewear_28856 = 28856,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Dancewear_28857 = 28857,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Shadow_Ops_Uniform = 28858,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Shadow_Ops_Uniform_28859 = 28859,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Shadow_Ops_Uniform_28860 = 28860,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Shadow_Ops_Uniform_28861 = 28861,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Shadow_Ops_Uniform_28862 = 28862,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Shadow_Ops_Uniform_28863 = 28863,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Shadow_Ops_Uniform_28864 = 28864,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Shadow_Ops_Uniform_28865 = 28865,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Shadow_Ops_Uniform_28866 = 28866,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Shadow_Ops_Uniform_28867 = 28867,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Samurai_Garb = 28868,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Samurai_Garb_28869 = 28869,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Burroughs_Costume = 28870,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Samurai_Garb_28871 = 28871,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Samurai_Garb_28872 = 28872,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Samurai_Garb_28873 = 28873,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Samurai_Garb_28874 = 28874,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Samurai_Garb_28875 = 28875,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Samurai_Garb_28876 = 28876,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Samurai_Garb_28877 = 28877,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Yumizuki_High = 28878,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Yumizuki_High_28879 = 28879,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Gouto_Costume = 28880,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Ouran_High = 28881,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Yumizuki_High_28882 = 28882,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Ouran = 28883,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Ouran_28884 = 28884,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Ouran_High_28885 = 28885,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Imperial_Uniform = 28886,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Ouran_High_28887 = 28887,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Starlight_Outfit = 28888,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Starlight_Outfit_28889 = 28889,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Starlight_Outfit_28890 = 28890,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Starlight_Outfit_28891 = 28891,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Starlight_Outfit_28892 = 28892,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Starlight_Outfit_28893 = 28893,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Starlight_Outfit_28894 = 28894,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Starlight_Outfit_28895 = 28895,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Starlight_Outfit_28896 = 28896,
            /// <summary>
            /// 
            /// </summary>
            Starlight_Outfit_28897 = 28897,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Moonlight_Outfit_no_model = 28898,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Moonlight_Outfit_no_model_28899 = 28899,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Moonlight_Outfit_no_model_28900 = 28900,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Moonlight_Outfit_no_model_28901 = 28901,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Moonlight_Outfit_no_model_28902 = 28902,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Moonlight_Outfit_no_model_28903 = 28903,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Moonlight_Outfit_no_model_28904 = 28904,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Moonlight_Outfit_no_model_28905 = 28905,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Moonlight_Outfit_no_model_28906 = 28906,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Moonlight_Outfit_no_model_28907 = 28907,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Ultramarine_Outfit = 28908,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Ultramarine_Outfit_28909 = 28909,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Long_Nose_Outfit = 28910,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Ultramarine_Outfit_28911 = 28911,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Ultramarine_Outfit_28912 = 28912,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Ultramarine_Outfit_28913 = 28913,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Ultramarine_Outfit_28914 = 28914,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Ultramarine_Outfit_28915 = 28915,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Ultramarine_Outfit_28916 = 28916,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Ultramarine_Outfit_28917 = 28917,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Featherman_Suit = 28918,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Featherman_Suit_28919 = 28919,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Featherman_Suit_28920 = 28920,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Featherman_Suit_28921 = 28921,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Featherman_Suit_28922 = 28922,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Featherman_Suit_28923 = 28923,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Featherman_Suit_28924 = 28924,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Featherman_Suit_28925 = 28925,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Featherman_Suit_28926 = 28926,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Featherman_Suit_28927 = 28927,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Demonica_Head = 28928,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Demonica_Head_28929 = 28929,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Demonica_Head_28930 = 28930,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Demonica_Head_28931 = 28931,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Demonica_Head_28932 = 28932,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Demonica_Head_28933 = 28933,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Demonica_Head_28934 = 28934,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Demonica_Head_28935 = 28935,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Demonica_Head_28936 = 28936,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Demonica_Head_28937 = 28937,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Demonica_Suit = 28938,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            Demonica_Suit_28939 = 28939,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            Demonica_Suit_28940 = 28940,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            Demonica_Suit_28941 = 28941,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            Demonica_Suit_28942 = 28942,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            Demonica_Suit_28943 = 28943,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            Demonica_Suit_28944 = 28944,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            Demonica_Suit_28945 = 28945,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            Demonica_Suit_28946 = 28946,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            Demonica_Suit_28947 = 28947,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            New_Cinema_Outfit = 28948,
            /// <summary>
            /// Useable by Ryuji
            /// </summary>
            New_Cinema_Outfit_28949 = 28949,
            /// <summary>
            /// Useable by Morgana
            /// </summary>
            New_Cinema_Outfit_28950 = 28950,
            /// <summary>
            /// Useable by Ann
            /// </summary>
            New_Cinema_Outfit_28951 = 28951,
            /// <summary>
            /// Useable by Yusuke
            /// </summary>
            New_Cinema_Outfit_28952 = 28952,
            /// <summary>
            /// Useable by Makoto
            /// </summary>
            New_Cinema_Outfit_28953 = 28953,
            /// <summary>
            /// Useable by Haru
            /// </summary>
            New_Cinema_Outfit_28954 = 28954,
            /// <summary>
            /// Useable by Futaba
            /// </summary>
            New_Cinema_Outfit_28955 = 28955,
            /// <summary>
            /// Useable by Akechi
            /// </summary>
            New_Cinema_Outfit_28956 = 28956,
            /// <summary>
            /// Useable by Yoshizawa
            /// </summary>
            New_Cinema_Outfit_28957 = 28957,
            /// <summary>
            /// Useable by None
            /// </summary>
            Blank = 32768,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            Unused_32769= 32769,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Unused_32770 = 32770,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Unused_32771 = 32771,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Unused_32772 = 32772,
            /// <summary>
            /// Useable by Fox (Handgun icon)
            /// </summary>
            Unused_32773 = 32773,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            Unused_32774 = 32774,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            Unused_32775 = 32775,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            Unused_32776 = 32776,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            Unused_32777 = 32777,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Unused_32778 = 32778,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            Unused_32779 = 32779,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            Unused_32780 = 32780,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            Unused_32781 = 32781,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            Unused_32782 = 32782,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            Unused_32783 = 32783,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Tkachev = 32784,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Governance = 32785,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_32786 = 32786,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Riot_Police = 32787,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_32788 = 32788,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Makaronov = 32789,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Nataraja_EX = 32790,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_32791 = 32791,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_32792 = 32792,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_32793 = 32793,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_32794 = 32794,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Jig_227 = 32795,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_32796 = 32796,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_32797 = 32797,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Tyrant_Pistol_EX = 32798,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Model_Gun = 32799,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Levinson_M31 = 32800,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32801 = 32801,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Granelli_M3 = 32802,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32803 = 32803,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32804 = 32804,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Bianchi_SBAS = 32805,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32806 = 32806,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Fireworks = 32807,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Pumpkin_Buster = 32808,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Megido_Blaster = 32809,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32810 = 32810,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32811 = 32811,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Pumpkin_Bomb = 32812,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32813 = 32813,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Masterkey = 32814,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32815 = 32815,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32816 = 32816,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32817 = 32817,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32818 = 32818,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32819 = 32819,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32820 = 32820,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32821 = 32821,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32822 = 32822,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32823 = 32823,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32824 = 32824,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32825 = 32825,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Reversion = 32826,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32827 = 32827,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32828 = 32828,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32829 = 32829,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Hellfire = 32830,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            RESERVE_32831 = 32831,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Slingshot = 32832,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32833 = 32833,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32834 = 32834,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32835 = 32835,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Shrike = 32836,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32837 = 32837,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Cat_Buster = 32838,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Comet_3 = 32839,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32840 = 32840,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Sudarshana_EX = 32841,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32842 = 32842,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32843 = 32843,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32844 = 32844,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32845 = 32845,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32846 = 32846,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32847 = 32847,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32848 = 32848,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32849 = 32849,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32850 = 32850,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Dreamstone = 32851,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32852 = 32852,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32853 = 32853,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32854 = 32854,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32855 = 32855,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32856 = 32856,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Falcon = 32857,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Catnap = 32858,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32859 = 32859,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32860 = 32860,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Northern_Light = 32861,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Shooting_Star = 32862,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Star_Slayer = 32863,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Replica_SMG = 32864,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32865 = 32865,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32866 = 32866,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Trooper = 32867,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32868 = 32868,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32869 = 32869,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Blitz_MG = 32870,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32871 = 32871,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32872 = 32872,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32873 = 32873,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32874 = 32874,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32875 = 32875,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            No_Mercy = 32876,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32877 = 32877,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Western_SMG = 32878,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32879 = 32879,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32880 = 32880,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32881 = 32881,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32882 = 32882,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            H_Renhappou = 32883,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32884 = 32884,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32885 = 32885,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32886 = 32886,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32887 = 32887,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32888 = 32888,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Balalaika = 32889,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Sterlidge = 32890,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Brain_Shot = 32891,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Pink_Buster = 32892,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Gungnir = 32893,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Tarantula = 32894,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32895 = 32895,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Replica_AR = 32896,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Black_Assault = 32897,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32898 = 32898,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Heavy_Assault = 32899,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32900 = 32900,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32901 = 32901,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32902 = 32902,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32903 = 32903,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32904 = 32904,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32905 = 32905,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32906 = 32906,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Annihilator = 32907,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32908 = 32908,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            AR_X = 32909,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32910 = 32910,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Hizutsu = 32911,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32912 = 32912,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            K_Gouhou_EX = 32913,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Providence = 32914,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32915 = 32915,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32916 = 32916,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32917 = 32917,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32918 = 32918,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32919 = 32919,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            K_Gouhou = 32920,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32921 = 32921,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Rebel_Rifle = 32922,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32923 = 32923,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Star_H = 32924,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            RESERVE_32925 = 32925,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Ryuraihou = 32926,
            /// <summary>
            /// Useable by Fox
            /// </summary>
            Heavens_Gate = 32927,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Replica_Revolver = 32928,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Peacemaker = 32929,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32930 = 32930,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32931 = 32931,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32932 = 32932,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Ling_Xing = 32933,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32934 = 32934,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32935 = 32935,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32936 = 32936,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32937 = 32937,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32938 = 32938,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32939 = 32939,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32940 = 32940,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Mirrirmina_EX = 32941,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Judge_End = 32942,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32943 = 32943,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32944 = 32944,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32945 = 32945,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32946 = 32946,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32947 = 32947,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Unlimited = 32948,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            RESERVE_32949 = 32949,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Mirrirmina = 32950,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Wildborn = 32951,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Baptism = 32952,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Orochi = 32953,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Twilight = 32954,
            /// <summary>
            /// Useable by Queen
            /// </summary>
            Judge_of_Hell = 32955,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Fury = 32956,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Calamity_Gun = 32957,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Kiraihou = 32958,
            /// <summary>
            /// Useable by Skull
            /// </summary>
            Megido_Fire = 32959,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            GL_Replica = 32960,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Pawzooka = 32961,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32962 = 32962,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32963 = 32963,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32964 = 32964,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Scorcher = 32965,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Paw_omber = 32966,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32967 = 32967,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32968 = 32968,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32969 = 32969,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32970 = 32970,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Eraser = 32971,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Milkor = 32972,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Yagrush_EX = 32973,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32974 = 32974,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32975 = 32975,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32976 = 32976,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32977 = 32977,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32978 = 32978,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32979 = 32979,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Town_Burner = 32980,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            RESERVE_32981 = 32981,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Pandemonium = 32982,
            /// <summary>
            /// Useable by Noir
            /// </summary>
            Yagrush = 32983,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32984 = 32984,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            RESERVE_32985 = 32985,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Phantom_Killer = 32986,
            /// <summary>
            /// Useable by Panther
            /// </summary>
            Wild_Hunt = 32987,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32988 = 32988,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            RESERVE_32989 = 32989,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            RESERVE_32990 = 32990,
            /// <summary>
            /// Useable by All (Handgun icon)
            /// </summary>
            RESERVE_32991 = 32991,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Moebius = 32992,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            RESERVE_32993 = 32993,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Sirius = 32994,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Red_Five = 32995,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Slingbow = 32996,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            RESERVE_32997 = 32997,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Utopia = 32998,
            /// <summary>
            /// Useable by Mona
            /// </summary>
            Sudarshana = 32999,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_33000 = 33000,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_33001 = 33001,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            From_Heaven = 33002,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Doomsday = 33003,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Ancient_Day = 33004,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_33005 = 33005,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_33006 = 33006,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_33007 = 33007,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RIPistol = 33008,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Casino_Start = 33009,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            Sahasrara = 33010,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            Sahasrara_EX = 33011,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Nataraja = 33012,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            RESERVE_33013 = 33013,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Sand_Hawk = 33014,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Eliminator = 33015,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Crimson_Gun = 33016,
            /// <summary>
            /// Useable by Crow
            /// </summary>
            Mauser = 33017,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            Yellow_Girl = 33018,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Cocytus = 33019,
            /// <summary>
            /// Useable by Joker
            /// </summary>
            Tyrant_Pistol = 33020,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            W_Rifle_Replica = 33021,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            Casino_Battle_Gun = 33022,
            /// <summary>
            /// Useable by Violet
            /// </summary>
            Roosevelt = 33023,
        }
    }
}
