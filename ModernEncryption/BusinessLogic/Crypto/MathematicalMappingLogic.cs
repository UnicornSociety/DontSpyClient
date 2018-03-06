using System.Collections.Generic;
using ModernEncryption.Model;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class MathematicalMappingLogic
    {
        public static Dictionary<char, Interval> IntervalTable { get; set; } = new Dictionary<char, Interval>();
        public static Dictionary<int, char> TransformationTable { get; set; } = new Dictionary<int, char>();
        public static Dictionary<char, int> BackTransformationTable { get; set; } = new Dictionary<char, int>();
        public static Dictionary<int, int> KeyTable = new Dictionary<int, int>();

        public void InitalizeIntervalTable()
        {
            var a = new Interval(1, 360);

            var b = new Interval(361, 469);

            var c = new Interval(470, 651);

            var d = new Interval(652, 947);

            var e = new Interval(948, 1913);

            var f = new Interval(1914, 2008);

            var g = new Interval(2009, 2185);

            var h = new Interval(2186, 2467);

            var i = new Interval(2468, 2913);

            var j = new Interval(2914, 2926);

            var k = new Interval(2927, 2994);

            var l = new Interval(2995, 3194);

            var m = new Interval(3195, 3339);

            var n = new Interval(3340, 3917);

            var o = new Interval(3918, 4042);

            var p = new Interval(4043, 4087);

            var q = new Interval(4088, 4091);

            var r = new Interval(4092, 4505);

            var s = new Interval(4506, 4933);

            var t = new Interval(4934, 5297);

            var u = new Interval(5298, 5532);

            var v = new Interval(5533, 5568);

            var w = new Interval(5569, 5677);

            var x = new Interval(5678, 5681);

            var y = new Interval(5682, 5685);

            var z = new Interval(5686, 5748);

            var sharpS = new Interval(5749, 5768);

            var ä = new Interval(5769, 5818);

            var ö = new Interval(5819, 5868);

            var ü = new Interval(5869, 5918);

            var A = new Interval(5919, 5960);

            var B = new Interval(5961, 5972);

            var C = new Interval(5973, 5992);

            var D = new Interval(5993, 6024);

            var E = new Interval(6025, 6130);

            var F = new Interval(6131, 6140);

            var G = new Interval(6141, 6159);

            var H = new Interval(6160, 6191);

            var I = new Interval(6192, 6240);

            var J = new Interval(6241, 6242);

            var K = new Interval(6243, 6249);

            var L = new Interval(6250, 6271);

            var M = new Interval(6272, 6287);

            var N = new Interval(6288, 6351);

            var O = new Interval(6352, 6367);

            var P = new Interval(6368, 6372);

            var Q = new Interval(6373, 6374);

            var R = new Interval(6375, 6420);

            var S = new Interval(6421, 6467);

            var T = new Interval(6468, 6507);

            var U = new Interval(6508, 6535);

            var V = new Interval(6536, 6539);

            var W = new Interval(6540, 6551);

            var X = new Interval(6552, 6553);

            var Y = new Interval(6554, 6555);

            var Z = new Interval(6556, 6562);

            var Ä = new Interval(6563, 6567);

            var Ö = new Interval(6568, 6572);

            var Ü = new Interval(6573, 6577);

            var one = new Interval(6578, 6579);

            var two = new Interval(6580, 6581);

            var three = new Interval(6582, 6583);

            var four = new Interval(6584, 6585);

            var five = new Interval(6586, 6587);

            var six = new Interval(6588, 6589);

            var seven = new Interval(6590, 6591);

            var eight = new Interval(6592, 6593);

            var nine = new Interval(6594, 6595);

            var zero = new Interval(6596, 6597);

            var dot = new Interval(6598, 6678);

            var comma = new Interval(6679, 6794);

            var space = new Interval(6795, 8064);

            var fragez = new Interval(8065, 8066);

            var ausrufez = new Interval(8067, 8068);

            var plus = new Interval(8069, 8070);

            var minus = new Interval(8071, 8072);

            var mal = new Interval(8073, 8074);

            var slash = new Interval(8075, 8076);

            var semikolon = new Interval(8077, 8078);

            var doppelp = new Interval(8079, 8080);

            var paragraph = new Interval(8081, 8082);

            var prozent = new Interval(8083, 8084);

            var und = new Interval(8085, 8086);

            var euro = new Interval(8087, 8088);

            var klammerAuf = new Interval(8089, 8090);

            var klammerZu = new Interval(8091, 8092);

            var gleich = new Interval(8093, 8094);

            var hashtag = new Interval(8095, 8096);

            var unterstrich = new Interval(8097, 8098);

            var at = new Interval(8099, 8100);



            IntervalTable.Add('a', a);
            IntervalTable.Add('b', b);
            IntervalTable.Add('c', c);
            IntervalTable.Add('d', d);
            IntervalTable.Add('e', e);
            IntervalTable.Add('f', f);
            IntervalTable.Add('g', g);
            IntervalTable.Add('h', h);
            IntervalTable.Add('i', i);
            IntervalTable.Add('j', j);
            IntervalTable.Add('k', k);
            IntervalTable.Add('l', l);
            IntervalTable.Add('m', m);
            IntervalTable.Add('n', n);
            IntervalTable.Add('o', o);
            IntervalTable.Add('p', p);
            IntervalTable.Add('q', q);
            IntervalTable.Add('r', r);
            IntervalTable.Add('s', s);
            IntervalTable.Add('t', t);
            IntervalTable.Add('u', u);
            IntervalTable.Add('v', v);
            IntervalTable.Add('w', w);
            IntervalTable.Add('x', x);
            IntervalTable.Add('y', y);
            IntervalTable.Add('z', z);
            IntervalTable.Add('ß', sharpS);
            IntervalTable.Add('ä', ä);
            IntervalTable.Add('ö', ö);
            IntervalTable.Add('ü', ü);
            IntervalTable.Add('A', A);
            IntervalTable.Add('B', B);
            IntervalTable.Add('C', C);
            IntervalTable.Add('D', D);
            IntervalTable.Add('E', E);
            IntervalTable.Add('F', F);
            IntervalTable.Add('G', G);
            IntervalTable.Add('H', H);
            IntervalTable.Add('I', I);
            IntervalTable.Add('J', J);
            IntervalTable.Add('K', K);
            IntervalTable.Add('L', L);
            IntervalTable.Add('M', M);
            IntervalTable.Add('N', N);
            IntervalTable.Add('O', O);
            IntervalTable.Add('P', P);
            IntervalTable.Add('Q', Q);
            IntervalTable.Add('R', R);
            IntervalTable.Add('S', S);
            IntervalTable.Add('T', T);
            IntervalTable.Add('U', U);
            IntervalTable.Add('V', V);
            IntervalTable.Add('W', W);
            IntervalTable.Add('X', X);
            IntervalTable.Add('Y', Y);
            IntervalTable.Add('Z', Z);
            IntervalTable.Add('Ä', Ä);
            IntervalTable.Add('Ö', Ö);
            IntervalTable.Add('Ü', Ü);
            IntervalTable.Add('1', one);
            IntervalTable.Add('2', two);
            IntervalTable.Add('3', three);
            IntervalTable.Add('4', four);
            IntervalTable.Add('5', five);
            IntervalTable.Add('6', six);
            IntervalTable.Add('7', seven);
            IntervalTable.Add('8', eight);
            IntervalTable.Add('9', nine);
            IntervalTable.Add('0', zero);
            IntervalTable.Add('.', dot);
            IntervalTable.Add(',', comma);
            IntervalTable.Add(' ', space);
            IntervalTable.Add('?', fragez);
            IntervalTable.Add('!', ausrufez);
            IntervalTable.Add('+', plus);
            IntervalTable.Add('-', minus);
            IntervalTable.Add('*', mal);
            IntervalTable.Add('/', slash);
            IntervalTable.Add(';', semikolon);
            IntervalTable.Add(':', doppelp);
            IntervalTable.Add('§', paragraph);
            IntervalTable.Add('%', prozent);
            IntervalTable.Add('&', und);
            IntervalTable.Add('€', euro);
            IntervalTable.Add('(', klammerAuf);
            IntervalTable.Add(')', klammerZu);
            IntervalTable.Add('=', gleich);
            IntervalTable.Add('#', hashtag);
            IntervalTable.Add('_', unterstrich);
            IntervalTable.Add('@', at);
        }

        public void InitalizeTransformationTable()
        {
            TransformationTable.Add(1, 'a');
            TransformationTable.Add(2, 'b');
            TransformationTable.Add(3, 'c');
            TransformationTable.Add(4, 'd');
            TransformationTable.Add(5, 'e');
            TransformationTable.Add(6, 'f');
            TransformationTable.Add(7, 'g');
            TransformationTable.Add(8, 'h');
            TransformationTable.Add(9, 'i');
            TransformationTable.Add(10, 'j');
            TransformationTable.Add(11, 'k');
            TransformationTable.Add(12, 'l');
            TransformationTable.Add(13, 'm');
            TransformationTable.Add(14, 'n');
            TransformationTable.Add(15, 'o');
            TransformationTable.Add(16, 'p');
            TransformationTable.Add(17, 'q');
            TransformationTable.Add(18, 'r');
            TransformationTable.Add(19, 's');
            TransformationTable.Add(20, 't');
            TransformationTable.Add(21, 'u');
            TransformationTable.Add(22, 'v');
            TransformationTable.Add(23, 'w');
            TransformationTable.Add(24, 'x');
            TransformationTable.Add(25, 'y');
            TransformationTable.Add(26, 'z');
            TransformationTable.Add(27, 'ß');
            TransformationTable.Add(28, 'ä');
            TransformationTable.Add(29, 'ö');
            TransformationTable.Add(30, 'ü');
            TransformationTable.Add(31, 'A');
            TransformationTable.Add(32, 'B');
            TransformationTable.Add(33, 'C');
            TransformationTable.Add(34, 'D');
            TransformationTable.Add(35, 'E');
            TransformationTable.Add(36, 'F');
            TransformationTable.Add(37, 'G');
            TransformationTable.Add(38, 'H');
            TransformationTable.Add(39, 'I');
            TransformationTable.Add(40, 'J');
            TransformationTable.Add(41, 'K');
            TransformationTable.Add(42, 'L');
            TransformationTable.Add(43, 'M');
            TransformationTable.Add(44, 'N');
            TransformationTable.Add(45, 'O');
            TransformationTable.Add(46, 'P');
            TransformationTable.Add(47, 'Q');
            TransformationTable.Add(48, 'R');
            TransformationTable.Add(49, 'S');
            TransformationTable.Add(50, 'T');
            TransformationTable.Add(51, 'U');
            TransformationTable.Add(52, 'V');
            TransformationTable.Add(53, 'W');
            TransformationTable.Add(54, 'X');
            TransformationTable.Add(55, 'Y');
            TransformationTable.Add(56, 'Z');
            TransformationTable.Add(57, 'Ä');
            TransformationTable.Add(58, 'Ö');
            TransformationTable.Add(59, 'Ü');
            TransformationTable.Add(60, '1');
            TransformationTable.Add(61, '2');
            TransformationTable.Add(62, '3');
            TransformationTable.Add(63, '4');
            TransformationTable.Add(64, '5');
            TransformationTable.Add(65, '6');
            TransformationTable.Add(66, '7');
            TransformationTable.Add(67, '8');
            TransformationTable.Add(68, '9');
            TransformationTable.Add(69, '0');
            TransformationTable.Add(70, '.');
            TransformationTable.Add(71, ',');
            TransformationTable.Add(72, ' ');
            TransformationTable.Add(73, '?');
            TransformationTable.Add(74, '!');
            TransformationTable.Add(75, '+');
            TransformationTable.Add(76, '-');
            TransformationTable.Add(77, '*');
            TransformationTable.Add(78, '/');
            TransformationTable.Add(79, ';');
            TransformationTable.Add(80, ':');
            TransformationTable.Add(81, '§');
            TransformationTable.Add(82, '%');
            TransformationTable.Add(83, '&');
            TransformationTable.Add(84, '€');
            TransformationTable.Add(85, '(');
            TransformationTable.Add(86, ')');
            TransformationTable.Add(87, '=');
            TransformationTable.Add(88, '#');
            TransformationTable.Add(89, '_');
            TransformationTable.Add(90, '@');
        }

        public void InitializeKeyTable()
        {

            KeyTable.Add(1, 1001);
            KeyTable.Add(2, 1002);
            KeyTable.Add(3, 1003);
            KeyTable.Add(4, 1004);
            KeyTable.Add(5, 1005);
            KeyTable.Add(6, 1006);
            KeyTable.Add(7, 1007);
            KeyTable.Add(8, 1008);
            KeyTable.Add(9, 1009);
            KeyTable.Add(10, 1010);
            KeyTable.Add(11, 1011);
            KeyTable.Add(12, 1012);
            KeyTable.Add(13, 1013);
            KeyTable.Add(14, 1014);
            KeyTable.Add(15, 1015);
            KeyTable.Add(16, 1016);
            KeyTable.Add(17, 1017);
            KeyTable.Add(18, 1018);
            KeyTable.Add(19, 1019);
            KeyTable.Add(20, 1020);
            KeyTable.Add(21, 1021);
            KeyTable.Add(22, 1022);
            KeyTable.Add(23, 1023);
            KeyTable.Add(24, 1024);
            KeyTable.Add(25, 1025);
            KeyTable.Add(26, 1026);
            KeyTable.Add(27, 1027);
            KeyTable.Add(28, 1028);
            KeyTable.Add(29, 1029);
            KeyTable.Add(30, 1030);
            KeyTable.Add(31, 1031);
            KeyTable.Add(32, 1032);
            KeyTable.Add(33, 1033);
            KeyTable.Add(34, 1034);
            KeyTable.Add(35, 1035);
            KeyTable.Add(36, 1036);
            KeyTable.Add(37, 1037);
            KeyTable.Add(38, 1038);
            KeyTable.Add(39, 1039);
            KeyTable.Add(40, 1040);
            KeyTable.Add(41, 1041);
            KeyTable.Add(42, 1042);
            KeyTable.Add(43, 1043);
            KeyTable.Add(44, 1044);
            KeyTable.Add(45, 1045);
            KeyTable.Add(46, 1046);
            KeyTable.Add(47, 1047);
            KeyTable.Add(48, 1048);
            KeyTable.Add(49, 1049);
            KeyTable.Add(50, 1050);
            KeyTable.Add(51, 1051);
            KeyTable.Add(52, 1052);
            KeyTable.Add(53, 1053);
            KeyTable.Add(54, 1054);
            KeyTable.Add(55, 1055);
            KeyTable.Add(56, 1056);
            KeyTable.Add(57, 1057);
            KeyTable.Add(58, 1058);
            KeyTable.Add(59, 1059);
            KeyTable.Add(60, 1060);
            KeyTable.Add(61, 1061);
            KeyTable.Add(62, 1062);
            KeyTable.Add(63, 1063);
            KeyTable.Add(64, 1064);
            KeyTable.Add(65, 1065);
            KeyTable.Add(66, 1066);
            KeyTable.Add(67, 1067);
            KeyTable.Add(68, 1068);
            KeyTable.Add(69, 1069);
            KeyTable.Add(70, 1070);
            KeyTable.Add(71, 1071);
            KeyTable.Add(72, 1072);
            KeyTable.Add(73, 1073);
            KeyTable.Add(74, 1074);
            KeyTable.Add(75, 1075);
            KeyTable.Add(76, 1076);
            KeyTable.Add(77, 1077);
            KeyTable.Add(78, 1078);
            KeyTable.Add(79, 1079);
            KeyTable.Add(80, 1080);
            KeyTable.Add(81, 1081);
            KeyTable.Add(82, 1082);
            KeyTable.Add(83, 1083);
            KeyTable.Add(84, 1084);
            KeyTable.Add(85, 1085);
            KeyTable.Add(86, 1086);
            KeyTable.Add(87, 1087);
            KeyTable.Add(88, 1088);
            KeyTable.Add(89, 1089);
            KeyTable.Add(90, 1090);
            KeyTable.Add(91, 1091);
            KeyTable.Add(92, 1092);
            KeyTable.Add(93, 1093);
            KeyTable.Add(94, 1094);
            KeyTable.Add(95, 1095);
            KeyTable.Add(96, 1096);
            KeyTable.Add(97, 1097);
            KeyTable.Add(98, 1098);
            KeyTable.Add(99, 1099);
            KeyTable.Add(100, 1100);
            KeyTable.Add(101, 1101);
            KeyTable.Add(102, 1102);
            KeyTable.Add(103, 1103);
            KeyTable.Add(104, 1104);
            KeyTable.Add(105, 1105);
            KeyTable.Add(106, 1106);
            KeyTable.Add(107, 1107);
            KeyTable.Add(108, 1108);
            KeyTable.Add(109, 1109);
            KeyTable.Add(110, 1110);
            KeyTable.Add(111, 1111);
            KeyTable.Add(112, 1112);
            KeyTable.Add(113, 1113);
            KeyTable.Add(114, 1114);
            KeyTable.Add(115, 1115);
            KeyTable.Add(116, 1116);
            KeyTable.Add(117, 1117);
            KeyTable.Add(118, 1118);
            KeyTable.Add(119, 1119);
            KeyTable.Add(120, 1120);
            KeyTable.Add(121, 1121);
            KeyTable.Add(122, 1122);
            KeyTable.Add(123, 1123);
            KeyTable.Add(124, 1124);
            KeyTable.Add(125, 1125);
            KeyTable.Add(126, 1126);
            KeyTable.Add(127, 1127);
            KeyTable.Add(128, 1128);
            KeyTable.Add(129, 1129);
            KeyTable.Add(130, 1130);
            KeyTable.Add(131, 1131);
            KeyTable.Add(132, 1132);
            KeyTable.Add(133, 1133);
            KeyTable.Add(134, 1134);
            KeyTable.Add(135, 1135);
            KeyTable.Add(136, 1136);
            KeyTable.Add(137, 1137);
            KeyTable.Add(138, 1138);
            KeyTable.Add(139, 1139);
            KeyTable.Add(140, 1140);
            KeyTable.Add(141, 1141);
            KeyTable.Add(142, 1142);
            KeyTable.Add(143, 1143);
            KeyTable.Add(144, 1144);
            KeyTable.Add(145, 1145);
            KeyTable.Add(146, 1146);
            KeyTable.Add(147, 1147);
            KeyTable.Add(148, 1148);
            KeyTable.Add(149, 1149);
            KeyTable.Add(150, 1150);
            KeyTable.Add(151, 1151);
            KeyTable.Add(152, 1152);
            KeyTable.Add(153, 1153);
            KeyTable.Add(154, 1154);
            KeyTable.Add(155, 1155);
            KeyTable.Add(156, 1156);
            KeyTable.Add(157, 1157);
            KeyTable.Add(158, 1158);
            KeyTable.Add(159, 1159);
            KeyTable.Add(160, 1160);
            KeyTable.Add(161, 1161);
            KeyTable.Add(162, 1162);
            KeyTable.Add(163, 1163);
            KeyTable.Add(164, 1164);
            KeyTable.Add(165, 1165);
            KeyTable.Add(166, 1166);
            KeyTable.Add(167, 1167);
            KeyTable.Add(168, 1168);
            KeyTable.Add(169, 1169);
            KeyTable.Add(170, 1170);
            KeyTable.Add(171, 1171);
            KeyTable.Add(172, 1172);
            KeyTable.Add(173, 1173);
            KeyTable.Add(174, 1174);
            KeyTable.Add(175, 1175);
            KeyTable.Add(176, 1176);
            KeyTable.Add(177, 1177);
            KeyTable.Add(178, 1178);
            KeyTable.Add(179, 1179);
            KeyTable.Add(180, 1180);
            KeyTable.Add(181, 1181);
            KeyTable.Add(182, 1182);
            KeyTable.Add(183, 1183);
            KeyTable.Add(184, 1184);
            KeyTable.Add(185, 1185);
            KeyTable.Add(186, 1186);
            KeyTable.Add(187, 1187);
            KeyTable.Add(188, 1188);
            KeyTable.Add(189, 1189);
            KeyTable.Add(190, 1190);
            KeyTable.Add(191, 1191);
            KeyTable.Add(192, 1192);
            KeyTable.Add(193, 1193);
            KeyTable.Add(194, 1194);
            KeyTable.Add(195, 1195);
            KeyTable.Add(196, 1196);
            KeyTable.Add(197, 1197);
            KeyTable.Add(198, 1198);
            KeyTable.Add(199, 1199);
            KeyTable.Add(200, 1200);
            KeyTable.Add(201, 1201);
            KeyTable.Add(202, 1202);
            KeyTable.Add(203, 1203);
            KeyTable.Add(204, 1204);
            KeyTable.Add(205, 1205);
            KeyTable.Add(206, 1206);
            KeyTable.Add(207, 1207);
            KeyTable.Add(208, 1208);
            KeyTable.Add(209, 1209);
            KeyTable.Add(210, 1210);
            KeyTable.Add(211, 1211);
            KeyTable.Add(212, 1212);
            KeyTable.Add(213, 1213);
            KeyTable.Add(214, 1214);
            KeyTable.Add(215, 1215);
            KeyTable.Add(216, 1216);
            KeyTable.Add(217, 1217);
            KeyTable.Add(218, 1218);
            KeyTable.Add(219, 1219);
            KeyTable.Add(220, 1220);
            KeyTable.Add(221, 1221);
            KeyTable.Add(222, 1222);
            KeyTable.Add(223, 1223);
            KeyTable.Add(224, 1224);
            KeyTable.Add(225, 1225);
            KeyTable.Add(226, 1226);
            KeyTable.Add(227, 1227);
            KeyTable.Add(228, 1228);
            KeyTable.Add(229, 1229);
            KeyTable.Add(230, 1230);
            KeyTable.Add(231, 1231);
            KeyTable.Add(232, 1232);
            KeyTable.Add(233, 1233);
            KeyTable.Add(234, 1234);
            KeyTable.Add(235, 1235);
            KeyTable.Add(236, 1236);
            KeyTable.Add(237, 1237);
            KeyTable.Add(238, 1238);
            KeyTable.Add(239, 1239);
            KeyTable.Add(240, 1240);
            KeyTable.Add(241, 1241);
            KeyTable.Add(242, 1242);
            KeyTable.Add(243, 1243);
            KeyTable.Add(244, 1244);
            KeyTable.Add(245, 1245);
            KeyTable.Add(246, 1246);
            KeyTable.Add(247, 1247);
            KeyTable.Add(248, 1248);
            KeyTable.Add(249, 1249);
            KeyTable.Add(250, 1250);
            KeyTable.Add(251, 1251);
            KeyTable.Add(252, 1252);
            KeyTable.Add(253, 1253);
            KeyTable.Add(254, 1254);
            KeyTable.Add(255, 1255);
            KeyTable.Add(256, 1256);
            KeyTable.Add(257, 1257);
            KeyTable.Add(258, 1258);
            KeyTable.Add(259, 1259);
            KeyTable.Add(260, 1260);
            KeyTable.Add(261, 1261);
            KeyTable.Add(262, 1262);
            KeyTable.Add(263, 1263);
            KeyTable.Add(264, 1264);
            KeyTable.Add(265, 1265);
            KeyTable.Add(266, 1266);
            KeyTable.Add(267, 1267);
            KeyTable.Add(268, 1268);
            KeyTable.Add(269, 1269);
            KeyTable.Add(270, 1270);
            KeyTable.Add(271, 1271);
            KeyTable.Add(272, 1272);
            KeyTable.Add(273, 1273);
            KeyTable.Add(274, 1274);
            KeyTable.Add(275, 1275);
            KeyTable.Add(276, 1276);
            KeyTable.Add(277, 1277);
            KeyTable.Add(278, 1278);
            KeyTable.Add(279, 1279);
            KeyTable.Add(280, 1280);
            KeyTable.Add(281, 1281);
            KeyTable.Add(282, 1282);
            KeyTable.Add(283, 1283);
            KeyTable.Add(284, 1284);
            KeyTable.Add(285, 1285);
            KeyTable.Add(286, 1286);
            KeyTable.Add(287, 1287);
            KeyTable.Add(288, 1288);
            KeyTable.Add(289, 1289);
            KeyTable.Add(290, 1290);
            KeyTable.Add(291, 1291);
            KeyTable.Add(292, 1292);
            KeyTable.Add(293, 1293);
            KeyTable.Add(294, 1294);
            KeyTable.Add(295, 1295);
            KeyTable.Add(296, 1296);
            KeyTable.Add(297, 1297);
            KeyTable.Add(298, 1298);
            KeyTable.Add(299, 1299);
            KeyTable.Add(300, 1300);
            KeyTable.Add(301, 1301);
            KeyTable.Add(302, 1302);
            KeyTable.Add(303, 1303);
            KeyTable.Add(304, 1304);
            KeyTable.Add(305, 1305);
            KeyTable.Add(306, 1306);
            KeyTable.Add(307, 1307);
            KeyTable.Add(308, 1308);
            KeyTable.Add(309, 1309);
            KeyTable.Add(310, 1310);

            KeyTable.Add(1001, 1);
            KeyTable.Add(1002, 2);
            KeyTable.Add(1003, 3);
            KeyTable.Add(1004, 4);
            KeyTable.Add(1005, 5);
            KeyTable.Add(1006, 6);
            KeyTable.Add(1007, 7);
            KeyTable.Add(1008, 8);
            KeyTable.Add(1009, 9);
            KeyTable.Add(1010, 10);
            KeyTable.Add(1011, 11);
            KeyTable.Add(1012, 12);
            KeyTable.Add(1013, 13);
            KeyTable.Add(1014, 14);
            KeyTable.Add(1015, 15);
            KeyTable.Add(1016, 16);
            KeyTable.Add(1017, 17);
            KeyTable.Add(1018, 18);
            KeyTable.Add(1019, 19);
            KeyTable.Add(1020, 20);
            KeyTable.Add(1021, 21);
            KeyTable.Add(1022, 22);
            KeyTable.Add(1023, 23);
            KeyTable.Add(1024, 24);
            KeyTable.Add(1025, 25);
            KeyTable.Add(1026, 26);
            KeyTable.Add(1027, 27);
            KeyTable.Add(1028, 28);
            KeyTable.Add(1029, 29);
            KeyTable.Add(1030, 30);
            KeyTable.Add(1031, 31);
            KeyTable.Add(1032, 32);
            KeyTable.Add(1033, 33);
            KeyTable.Add(1034, 34);
            KeyTable.Add(1035, 35);
            KeyTable.Add(1036, 36);
            KeyTable.Add(1037, 37);
            KeyTable.Add(1038, 38);
            KeyTable.Add(1039, 39);
            KeyTable.Add(1040, 40);
            KeyTable.Add(1041, 41);
            KeyTable.Add(1042, 42);
            KeyTable.Add(1043, 43);
            KeyTable.Add(1044, 44);
            KeyTable.Add(1045, 45);
            KeyTable.Add(1046, 46);
            KeyTable.Add(1047, 47);
            KeyTable.Add(1048, 48);
            KeyTable.Add(1049, 49);
            KeyTable.Add(1050, 50);
            KeyTable.Add(1051, 51);
            KeyTable.Add(1052, 52);
            KeyTable.Add(1053, 53);
            KeyTable.Add(1054, 54);
            KeyTable.Add(1055, 55);
            KeyTable.Add(1056, 56);
            KeyTable.Add(1057, 57);
            KeyTable.Add(1058, 58);
            KeyTable.Add(1059, 59);
            KeyTable.Add(1060, 60);
            KeyTable.Add(1061, 61);
            KeyTable.Add(1062, 62);
            KeyTable.Add(1063, 63);
            KeyTable.Add(1064, 64);
            KeyTable.Add(1065, 65);
            KeyTable.Add(1066, 66);
            KeyTable.Add(1067, 67);
            KeyTable.Add(1068, 68);
            KeyTable.Add(1069, 69);
            KeyTable.Add(1070, 70);
            KeyTable.Add(1071, 71);
            KeyTable.Add(1072, 72);
            KeyTable.Add(1073, 73);
            KeyTable.Add(1074, 74);
            KeyTable.Add(1075, 75);
            KeyTable.Add(1076, 76);
            KeyTable.Add(1077, 77);
            KeyTable.Add(1078, 78);
            KeyTable.Add(1079, 79);
            KeyTable.Add(1080, 80);
            KeyTable.Add(1081, 81);
            KeyTable.Add(1082, 82);
            KeyTable.Add(1083, 83);
            KeyTable.Add(1084, 84);
            KeyTable.Add(1085, 85);
            KeyTable.Add(1086, 86);
            KeyTable.Add(1087, 87);
            KeyTable.Add(1088, 88);
            KeyTable.Add(1089, 89);
            KeyTable.Add(1090, 90);
            KeyTable.Add(1091, 91);
            KeyTable.Add(1092, 92);
            KeyTable.Add(1093, 93);
            KeyTable.Add(1094, 94);
            KeyTable.Add(1095, 95);
            KeyTable.Add(1096, 96);
            KeyTable.Add(1097, 97);
            KeyTable.Add(1098, 98);
            KeyTable.Add(1099, 99);
            KeyTable.Add(1100, 100);
            KeyTable.Add(1101, 101);
            KeyTable.Add(1102, 102);
            KeyTable.Add(1103, 103);
            KeyTable.Add(1104, 104);
            KeyTable.Add(1105, 105);
            KeyTable.Add(1106, 106);
            KeyTable.Add(1107, 107);
            KeyTable.Add(1108, 108);
            KeyTable.Add(1109, 109);
            KeyTable.Add(1110, 110);
            KeyTable.Add(1111, 111);
            KeyTable.Add(1112, 112);
            KeyTable.Add(1113, 113);
            KeyTable.Add(1114, 114);
            KeyTable.Add(1115, 115);
            KeyTable.Add(1116, 116);
            KeyTable.Add(1117, 117);
            KeyTable.Add(1118, 118);
            KeyTable.Add(1119, 119);
            KeyTable.Add(1120, 120);
            KeyTable.Add(1121, 121);
            KeyTable.Add(1122, 122);
            KeyTable.Add(1123, 123);
            KeyTable.Add(1124, 124);
            KeyTable.Add(1125, 125);
            KeyTable.Add(1126, 126);
            KeyTable.Add(1127, 127);
            KeyTable.Add(1128, 128);
            KeyTable.Add(1129, 129);
            KeyTable.Add(1130, 130);
            KeyTable.Add(1131, 131);
            KeyTable.Add(1132, 132);
            KeyTable.Add(1133, 133);
            KeyTable.Add(1134, 134);
            KeyTable.Add(1135, 135);
            KeyTable.Add(1136, 136);
            KeyTable.Add(1137, 137);
            KeyTable.Add(1138, 138);
            KeyTable.Add(1139, 139);
            KeyTable.Add(1140, 140);
            KeyTable.Add(1141, 141);
            KeyTable.Add(1142, 142);
            KeyTable.Add(1143, 143);
            KeyTable.Add(1144, 144);
            KeyTable.Add(1145, 145);
            KeyTable.Add(1146, 146);
            KeyTable.Add(1147, 147);
            KeyTable.Add(1148, 148);
            KeyTable.Add(1149, 149);
            KeyTable.Add(1150, 150);
            KeyTable.Add(1151, 151);
            KeyTable.Add(1152, 152);
            KeyTable.Add(1153, 153);
            KeyTable.Add(1154, 154);
            KeyTable.Add(1155, 155);
            KeyTable.Add(1156, 156);
            KeyTable.Add(1157, 157);
            KeyTable.Add(1158, 158);
            KeyTable.Add(1159, 159);
            KeyTable.Add(1160, 160);
            KeyTable.Add(1161, 161);
            KeyTable.Add(1162, 162);
            KeyTable.Add(1163, 163);
            KeyTable.Add(1164, 164);
            KeyTable.Add(1165, 165);
            KeyTable.Add(1166, 166);
            KeyTable.Add(1167, 167);
            KeyTable.Add(1168, 168);
            KeyTable.Add(1169, 169);
            KeyTable.Add(1170, 170);
            KeyTable.Add(1171, 171);
            KeyTable.Add(1172, 172);
            KeyTable.Add(1173, 173);
            KeyTable.Add(1174, 174);
            KeyTable.Add(1175, 175);
            KeyTable.Add(1176, 176);
            KeyTable.Add(1177, 177);
            KeyTable.Add(1178, 178);
            KeyTable.Add(1179, 179);
            KeyTable.Add(1180, 180);
            KeyTable.Add(1181, 181);
            KeyTable.Add(1182, 182);
            KeyTable.Add(1183, 183);
            KeyTable.Add(1184, 184);
            KeyTable.Add(1185, 185);
            KeyTable.Add(1186, 186);
            KeyTable.Add(1187, 187);
            KeyTable.Add(1188, 188);
            KeyTable.Add(1189, 189);
            KeyTable.Add(1190, 190);
            KeyTable.Add(1191, 191);
            KeyTable.Add(1192, 192);
            KeyTable.Add(1193, 193);
            KeyTable.Add(1194, 194);
            KeyTable.Add(1195, 195);
            KeyTable.Add(1196, 196);
            KeyTable.Add(1197, 197);
            KeyTable.Add(1198, 198);
            KeyTable.Add(1199, 199);
            KeyTable.Add(1200, 200);
            KeyTable.Add(1201, 201);
            KeyTable.Add(1202, 202);
            KeyTable.Add(1203, 203);
            KeyTable.Add(1204, 204);
            KeyTable.Add(1205, 205);
            KeyTable.Add(1206, 206);
            KeyTable.Add(1207, 207);
            KeyTable.Add(1208, 208);
            KeyTable.Add(1209, 209);
            KeyTable.Add(1210, 210);
            KeyTable.Add(1211, 211);
            KeyTable.Add(1212, 212);
            KeyTable.Add(1213, 213);
            KeyTable.Add(1214, 214);
            KeyTable.Add(1215, 215);
            KeyTable.Add(1216, 216);
            KeyTable.Add(1217, 217);
            KeyTable.Add(1218, 218);
            KeyTable.Add(1219, 219);
            KeyTable.Add(1220, 220);
            KeyTable.Add(1221, 221);
            KeyTable.Add(1222, 222);
            KeyTable.Add(1223, 223);
            KeyTable.Add(1224, 224);
            KeyTable.Add(1225, 225);
            KeyTable.Add(1226, 226);
            KeyTable.Add(1227, 227);
            KeyTable.Add(1228, 228);
            KeyTable.Add(1229, 229);
            KeyTable.Add(1230, 230);
            KeyTable.Add(1231, 231);
            KeyTable.Add(1232, 232);
            KeyTable.Add(1233, 233);
            KeyTable.Add(1234, 234);
            KeyTable.Add(1235, 235);
            KeyTable.Add(1236, 236);
            KeyTable.Add(1237, 237);
            KeyTable.Add(1238, 238);
            KeyTable.Add(1239, 239);
            KeyTable.Add(1240, 240);
            KeyTable.Add(1241, 241);
            KeyTable.Add(1242, 242);
            KeyTable.Add(1243, 243);
            KeyTable.Add(1244, 244);
            KeyTable.Add(1245, 245);
            KeyTable.Add(1246, 246);
            KeyTable.Add(1247, 247);
            KeyTable.Add(1248, 248);
            KeyTable.Add(1249, 249);
            KeyTable.Add(1250, 250);
            KeyTable.Add(1251, 251);
            KeyTable.Add(1252, 252);
            KeyTable.Add(1253, 253);
            KeyTable.Add(1254, 254);
            KeyTable.Add(1255, 255);
            KeyTable.Add(1256, 256);
            KeyTable.Add(1257, 257);
            KeyTable.Add(1258, 258);
            KeyTable.Add(1259, 259);
            KeyTable.Add(1260, 260);
            KeyTable.Add(1261, 261);
            KeyTable.Add(1262, 262);
            KeyTable.Add(1263, 263);
            KeyTable.Add(1264, 264);
            KeyTable.Add(1265, 265);
            KeyTable.Add(1266, 266);
            KeyTable.Add(1267, 267);
            KeyTable.Add(1268, 268);
            KeyTable.Add(1269, 269);
            KeyTable.Add(1270, 270);
            KeyTable.Add(1271, 271);
            KeyTable.Add(1272, 272);
            KeyTable.Add(1273, 273);
            KeyTable.Add(1274, 274);
            KeyTable.Add(1275, 275);
            KeyTable.Add(1276, 276);
            KeyTable.Add(1277, 277);
            KeyTable.Add(1278, 278);
            KeyTable.Add(1279, 279);
            KeyTable.Add(1280, 280);
            KeyTable.Add(1281, 281);
            KeyTable.Add(1282, 282);
            KeyTable.Add(1283, 283);
            KeyTable.Add(1284, 284);
            KeyTable.Add(1285, 285);
            KeyTable.Add(1286, 286);
            KeyTable.Add(1287, 287);
            KeyTable.Add(1288, 288);
            KeyTable.Add(1289, 289);
            KeyTable.Add(1290, 290);
            KeyTable.Add(1291, 291);
            KeyTable.Add(1292, 292);
            KeyTable.Add(1293, 293);
            KeyTable.Add(1294, 294);
            KeyTable.Add(1295, 295);
            KeyTable.Add(1296, 296);
            KeyTable.Add(1297, 297);
            KeyTable.Add(1298, 298);
            KeyTable.Add(1299, 299);
            KeyTable.Add(1300, 300);
            KeyTable.Add(1301, 301);
            KeyTable.Add(1302, 302);
            KeyTable.Add(1303, 303);
            KeyTable.Add(1304, 304);
            KeyTable.Add(1305, 305);
            KeyTable.Add(1306, 306);
            KeyTable.Add(1307, 307);
            KeyTable.Add(1308, 308);
            KeyTable.Add(1309, 309);
            KeyTable.Add(1310, 310);
        }

        public static string key { get; set; } = "842;843;844;845;841;846;847;848;849;850;851;852;853;854;840;855;856;857;858;859;860;861;862;863;839;864;865;866;867;868;869;870;871;838;872;873;874;875;876;877;878;879;880;837;881;882;883;884;885;886;887;888;889;836;890;891;892;893;894;895;896;897;835;898;899;900;901;902;903;904;905;906;834;907;908;909;910;911;912;913;914;833;915;916;917;918;919;920;921;922;923;832;924;925;926;927;928;929;930;931;932;831;933;934;935;936;937;938;939;940;830;941;942;943;944;945;946;947;948;949;829;950;951;952;953;954;955;956;957;828;958;959;960;961;962;963;964;965;966;827;967;968;969;970;971;972;973;974;975;826;976;977;978;979;980;981;982;983;825;984;985;986;987;988;989;990;991;992;824;993;994;995;996;997;998;999;1000;1001;823;1002;1003;1004;1005;1006;1007;1008;1009;822;1010;1011;1012;1013;1014;1015;1016;1017;1018;821;1019;1020;1021;1022;1023;1024;1025;1026;820;1027;1028;1029;1030;1031;1032;1033;1034;1035;819;1036;1037;1038;1039;1040;1041;1042;1043;1044;818;1045;1046;1047;1048;1049;1050;1051;1052;817;1053;1054;1055;1056;1057;1058;1059;1060;1061;816;1062;1063;1064;1065;1066;1067;1068;1069;1070;815;1071;1072;1073;1074;1075;1076;1077;1078;814;1079;1080;1081;1082;1083;1084;1085;1086;1087;813;1088;1089;1090;1091;1092;1093;1094;1095;812;1096;1097;1098;1099;1100;1101;1102;1103;1104;811;1105;1106;1107;1108;1109;1110;1111;1112;1113;810;1114;1115;1116;1117;1118;1119;1120;1121;809;1122;1123;1124;1125;1126;1127;1128;1129;1130;808;1131;1132;1133;1134;1135;1136;1137;1138;807;1139;1140;1141;1142;1143;1144;1145;1146;1147;806;1148;1149;1150;1151;1152;1153;1154;1155;1156;805;1157;1158;1159;1160;1161;1162;1163;1164;804;1165;1166;1167;1168;1169;1170;1171;1172;1173;803;1174;1175;1176;1177;1178;1179;1180;1181;1182;802;1183;1184;1185;1186;1187;1188;1189;1190;801;1191;7641;7640;7639;7638;7637;7636;7635;7634;7633;7632;7631;7630;7629;7642;7628;7627;7626;7625;7624;7623;7622;7621;7620;7619;7618;7617;7616;7615;7614;7613;7643;7612;7611;7610;7609;7608;7607;7606;7605;7604;7603;7602;7601;7600;7599;7598;7597;7644;7596;7595;7594;7593;7592;7591;7590;7589;7588;7587;7586;7585;7584;7583;7582;7581;7645;7580;7579;7578;7577;7576;7575;7574;7573;7572;7571;7570;7569;7568;7567;7566;7646;7565;7564;7563;7562;7561;7560;7559;7558;7557;7556;7555;7554;7553;7552;7551;7550;7647;7549;7548;7547;7546;7545;7544;7543;7542;7541;7540;7539;7538;7537;7536;7535;7534;7648;7533;7532;7531;7530;7529;7528;7527;7526;7525;7524;7523;7522;7521;7520;7519;7518;7649;7517;7516;7515;7514;7513;7512;7511;7510;7509;7508;7507;7506;7505;7504;7503;7650;7502;7501;7500;7499;7498;7497;7496;7495;7494;7493;7492;7491;7490;7489;7488;7487;7651;7486;7485;7484;7483;7482;7481;7480;7479;7478;7477;7476;7475;7474;7473;7472;7471;7652;7470;7469;7468;7467;7466;7465;7464;7463;7462;7461;7460;7459;7458;7457;7456;7455;7653;7454;7453;7452;7451;7450;7449;7448;7447;7446;7445;7444;7443;7442;7441;7440;7654;7439;7438;7437;7436;7435;7434;7433;7432;7431;7430;7429;7428;7427;7426;7425;7424;7655;7423;7422;7421;7420;7419;7418;7417;7416;7415;7414;7413;7412;7411;7410;7409;7408;7656;7407;7406;7405;7404;7403;7402;7401;7400;7399;7398;7397;7396;7395;7394;7393;7392;7657;7391;7390;7389;7388;7387;7386;7385;7384;7383;7382;7381;7380;7379;7378;7377;7376;7658;7375;7374;7373;7372;7371;7370;7369;7368;7367;7366;7365;7364;7363;7362;7361;7659;7360;7359;7358;7357;7356;7355;7354;7353;7352;7351;7350;7349;7348;7347;7346;7345;7660;7344;7343;7342;7341;7340;7339;7338;7337;7336;7335;7334;7333;7332;7331;7330;7329;7661;7328;7327;7326;7325;7324;7323;7322;7321;7320;7319;7318;7317;7316;7315;7314;7313;7662;7312;7311;7310;7309;7308;7307;7306;7305;7304;7303;7302;7301;7300;7299;7298;7663;7297;7296;7295;7294;7293;7292;7291;7290;7289;7288;7287;7286;7285;7284;7283;7282;7664;7281;7280;7279;7278;7277;7276;7275;7274;7273;7272;7271;7270;7269;7268;7267;7266;7665;7265;7264;7263;7262;7261;7260;7259;7258;7257;7256;7255;7254;7253;7252;7251;7250;7666;7249;7248;7247;7246;7245;7244;7243;7242;7241;7240;7239;7238;7237;7236;7235;7667;7234;7233;7232;7231;7230;7229;7228;7227;7226;7225;7224;7223;7222;7221;7220;7219;7668;7218;7217;7216;7215;7214;7213;7212;7211;7210;7209;7208;7207;7206;7205;7204;7203;7669;7202;7201;7200;7199;7198;7197;7196;7195;7194;7193;7192;7191;7190;7189;7188;7187;7670;7186;7185;7184;7183;7182;7181;7180;7179;7178;7177;7176;7175;7174;7173;7172;7171;7671;7170;7169;7168;7167;7166;7165;7164;7163;7162;7161;7160;7159;7158;7157;7156;7672;7155;7154;7153;7152;7151;7150;7149;7148;7147;7146;7145;7144;7143;7142;7141;7140;7673;7139;7138;7137;7136;7135;7134;7133;7132;7131;7130;7129;7128;7127;7126;7125;7124;7674;7123;7122;7121;7120;7119;7118;7117;7116;7115;7114;7113;7112;7111;7110;7109;7108;7675;7107;7106;7105;7104;7103;7102;7101;7100;7099;7098;7097;7096;7095;7094;7093;7676;7092;7091;7090;7089;7088;7087;7086;7085;7084;7083;7082;7081;7080;7079;7078;7077;7677;7076;7075;7074;7073;7072;7071;7070;7069;7068;7067;7066;7065;7064;7063;7062;7061;7678;7060;7059;7058;7057;7056;7055;7054;7053;7052;7051;7050;7049;7048;7047;7046;7045;7679;7044;7043;7042;7041;7040;7039;7038;7037;7036;7035;7034;7033;7032;7031;7030;7680;7029;7028;7027;7026;7025;7024;7023;7022;7021;7020;7019;7018;7017;7016;7015;7014;7681;7013;7012;7011;7010;7009;7008;7007;7006;7005;7004;7003;7002;7001;7000;6999;6998;7682;6997;6996;6995;6994;6993;6992;6991;6990;6989;6988;6987;6986;6985;6984;6983;6982;7683;6981;6980;6979;6978;6977;6976;6975;6974;6973;6972;6971;6970;6969;6968;6967;6966;7684;6965;6964;6963;6962;6961;6960;6959;6958;6957;6956;6955;6954;6953;6952;6951;7685;6950;6949;6948;6947;6946;6945;6944;6943;6942;6941;6940;6939;6938;6937;6936;6935;7686;6934;6933;6932;6931;6930;6929;6928;6927;6926;6925;6924;6923;6922;6921;6920;6919;7687;6918;6917;6916;6915;6914;6913;6912;6911;6910;6909;6908;6907;6906;6905;6904;6903;7688;6902;6901;6900;6899;6898;6897;6896;6895;6894;6893;6892;6891;6890;6889;6888;7689;6887;6886;6885;6884;6883;6882;6881;6880;6879;6878;6877;6876;6875;6874;6873;6872;7690;6871;6870;6869;6868;6867;6866;6865;6864;6863;6862;6861;6860;6859;6858;6857;6856;7691;6855;6854;6853;6852;6851;6850;6849;6848;6847;6846;6845;6844;6843;6842;6841;6840;7692;6839;6838;6837;6836;6835;6834;6833;6832;6831;6830;6829;6828;6827;6826;6825;7693;6824;6823;6822;6821;6820;6819;6818;6817;6816;6815;6814;6813;6812;6811;6810;6809;7694;6808;6807;6806;6805;6804;6803;6802;6801;6800;6799;6798;6797;6796;6795;6794;6793;7695;6792;6791;6790;6789;6788;6787;6786;6785;6784;6783;6782;6781;6780;6779;6778;6777;7696;6776;6775;6774;6773;6772;6771;6770;6769;6768;6767;6766;6765;6764;6763;6762;6761;7697;6760;6759;6758;6757;6756;6755;6754;6753;6752;6751;6750;6749;6748;6747;6746;7698;6745;6744;6743;6742;6741;6740;6739;6738;6737;6736;6735;6734;6733;6732;6731;6730;7699;6729;6728;6727;6726;6725;6724;6723;6722;6721;6720;6719;6718;6717;6716;6715;6714;7700;6713;6712;6711;6710;6709;6708;6707;6706;6705;6704;6703;6702;6701;6700;6699;6698;7701;6697;6696;6695;6694;6693;6692;6691;6690;6689;6688;6687;6686;6685;6684;6683;7702;6682;6681;6680;6679;6678;6677;6676;6675;6674;6673;6672;6671;6670;6669;6668;6667;7703;6666;6665;6664;6663;6662;6661;6660;6659;6658;6657;6656;6655;6654;6653;6652;6651;7704;6650;6649;6648;6647;6646;6645;6644;6643;6642;6641;6640;6639;6638;6637;6636;6635;7705;6634;6633;6632;6631;6630;6629;6628;6627;6626;6625;6624;6623;6622;6621;6620;7706;6619;6618;6617;6616;6615;6614;6613;6612;6611;6610;6609;6608;6607;6606;6605;6604;7707;6603;6602;6601;6600;6599;6598;6597;6596;6595;6594;6593;6592;6591;6590;6589;6588;7708;6587;6586;6585;6584;6583;6582;6581;6580;6579;6578;6577;6576;6575;6574;6573;6572;7709;6571;6570;6569;6568;6567;6566;6565;6564;6563;6562;6561;6560;6559;6558;6557;6556;7710;6555;6554;6553;6552;6551;6550;6549;6548;6547;6546;6545;6544;6543;6542;6541;7711;6540;6539;6538;6537;6536;6535;6534;6533;6532;6531;6530;6529;6528;6527;6526;6525;7712;6524;6523;6522;6521;6520;6519;6518;6517;6516;6515;6514;6513;6512;6511;6510;6509;7713;6508;6507;6506;6505;6504;6503;6502;6501;6500;6499;6498;6497;6496;6495;6494;6493;7714;6492;6491;6490;6489;6488;6487;6486;6485;6484;6483;6482;6481;6480;6479;6478;7715;6477;6476;6475;6474;6473;6472;6471;6470;6469;6468;6467;6466;6465;6464;6463;6462;7716;6461;6460;6459;6458;6457;6456;6455;6454;6453;6452;6451;6450;6449;6448;6447;6446;7717;6445;6444;6443;6442;6441;6440;6439;6438;6437;6436;6435;6434;6433;6432;6431;6430;7718;6429;6428;6427;6426;6425;6424;6423;6422;6421;6420;6419;6418;6417;6416;6415;7719;6414;6413;6412;6411;6410;6409;6408;6407;6406;6405;6404;6403;6402;6401;6400;6399;7720;6398;6397;6396;6395;6394;6393;6392;6391;6390;6389;6388;6387;6386;6385;6384;6383;7721;6382;6381;6380;6379;6378;6377;6376;6375;6374;6373;6372;6371;6370;6369;6368;6367;7722;6366;6365;6364;6363;6362;6361;6360;6359;6358;6357;6356;6355;6354;6353;6352;6351;7723;6350;6349;6348;6347;6346;6345;6344;6343;6342;6341;6340;6339;6338;6337;6336;7724;6335;6334;6333;6332;6331;6330;6329;6328;6327;6326;6325;6324;6323;6322;6321;6320;7725;6319;6318;6317;6316;6315;6314;6313;6312;6311;6310;6309;6308;6307;6306;6305;6304;7726;6303;6302;6301;6300;6299;6298;6297;6296;6295;6294;6293;6292;6291;6290;6289;6288;7727;6287;6286;6285;6284;6283;6282;6281;6280;6279;6278;6277;6276;6275;6274;6273;7728;6272;6271;6270;6269;6268;6267;6266;6265;6264;6263;6262;6261;6260;6259;6258;6257;7729;6256;6255;6254;6253;6252;6251;6250;6249;6248;6247;6246;6245;6244;6243;6242;6241;7730;6240;6239;6238;6237;6236;6235;6234;6233;6232;6231;6230;6229;6228;6227;6226;6225;7731;6224;6223;6222;6221;6220;6219;6218;6217;6216;6215;6214;6213;6212;6211;6210;7732;6209;6208;6207;6206;6205;6204;6203;6202;6201;6200;6199;6198;6197;6196;6195;6194;7733;6193;6192;6191;6190;6189;6188;6187;6186;6185;6184;6183;6182;6181;6180;6179;6178;7734;6177;6176;6175;6174;6173;6172;6171;6170;6169;6168;6167;6166;6165;6164;6163;6162;7735;6161;6160;6159;6158;6157;6156;6155;6154;6153;6152;6151;6150;6149;6148;6147;6146;7736;6145;6144;6143;6142;6141;6140;6139;6138;6137;6136;6135;6134;6133;6132;6131;7737;6130;6129;6128;6127;6126;6125;6124;6123;6122;6121;6120;6119;6118;6117;6116;6115;7738;6114;6113;6112;6111;6110;6109;6108;6107;6106;6105;6104;6103;6102;6101;6100;6099;7739;6098;6097;6096;6095;6094;6093;6092;6091;6090;6089;6088;6087;6086;6085;6084;6083;7740;6082;6081;6080;6079;6078;6077;6076;6075;6074;6073;6072;6071;6070;6069;6068;7741;6067;6066;6065;6064;6063;6062;6061;6060;6059;6058;6057;6056;6055;6054;6053;6052;7742;6051;6050;6049;6048;6047;6046;6045;6044;6043;6042;6041;6040;6039;6038;6037;6036;7743;6035;6034;6033;6032;6031;6030;6029;6028;6027;6026;6025;6024;6023;6022;6021;6020;7744;6019;6018;6017;6016;6015;6014;6013;6012;6011;6010;6009;6008;6007;6006;6005;7745;6004;6003;6002;6001;6000;5999;5998;5997;5996;5995;5994;5993;5992;5991;5990;5989;7746;5988;5987;5986;5985;5984;5983;5982;5981;5980;5979;5978;5977;5976;5975;5974;5973;7747;5972;5971;5970;5969;5968;5967;5966;5965;5964;5963;5962;5961;5960;5959;5958;5957;7748;5956;5955;5954;5953;5952;5951;5950;5949;5948;5947;5946;5945;5944;5943;5942;5941;7749;5940;5939;5938;5937;5936;5935;5934;5933;5932;5931;5930;5929;5928;5927;5926;7750;5925;5924;5923;5922;5921;5920;5919;5918;5917;5916;5915;5914;5913;5912;5911;5910;7751;5909;5908;5907;5906;5905;5904;5903;5902;5901;5900;5899;5898;5897;5896;5895;5894;7752;5893;5892;5891;5890;5889;5888;5887;5886;5885;5884;5883;5882;5881;5880;5879;5878;7753;5877;5876;5875;5874;5873;5872;5871;5870;5869;5868;5867;5866;5865;5864;5863;7754;5862;5861;5860;5859;5858;5857;5856;5855;5854;5853;5852;5851;5850;5849;5848;5847;7755;5846;5845;5844;5843;5842;5841;5840;5839;5838;5837;5836;5835;5834;5833;5832;5831;7756;5830;5829;5828;5827;5826;5825;5824;5823;5822;5821;5820;5819;5818;5817;5816;5815;7757;5814;5813;5812;5811;5810;5809;5808;5807;5806;5805;5804;5803;5802;5801;5800;7758;5799;5798;5797;5796;5795;5794;5793;5792;5791;5790;5789;5788;5787;5786;5785;5784;7759;5783;5782;5781;5780;5779;5778;5777;5776;5775;5774;5773;5772;5771;5770;5769;5768;7760;5767;5766;5765;5764;5763;5762;5761;5760;5759;5758;5757;5756;5755;5754;5753;5752;7761;5751;5750;5749;5748;5747;5746;5745;5744;5743;5742;5741;5740;5739;5738;5737;5736;7762;5735;5734;5733;5732;5731;5730;5729;5728;5727;5726;5725;5724;5723;5722;5721;7763;5720;5719;5718;5717;5716;5715;5714;5713;5712;5711;5710;5709;5708;5707;5706;5705;7764;5704;5703;5702;5701;5700;5699;5698;5697;5696;5695;5694;5693;5692;5691;5690;5689;7765;5688;5687;5686;5685;5684;5683;5682;5681;5680;5679;5678;5677;5676;5675;5674;5673;7766;5672;5671;5670;5669;5668;5667;5666;5665;5664;5663;5662;5661;5660;5659;5658;7767;5657;5656;5655;5654;5653;5652;5651;5650;5649;5648;5647;5646;5645;5644;5643;5642;7768;5641;5640;5639;5638;5637;5636;5635;5634;5633;5632;5631;5630;5629;5628;5627;5626;7769;5625;5624;5623;5622;5621;5620;5619;5618;5617;5616;5615;5614;5613;5612;5611;5610;7770;5609;5608;5607;5606;5605;5604;5603;5602;5601;5600;5599;5598;5597;5596;5595;5594;7771;5593;5592;5591;5590;5589;5588;5587;5586;5585;5584;5583;5582;5581;5580;5579;7772;5578;5577;5576;5575;5574;5573;5572;5571;5570;5569;5568;5567;5566;5565;5564;5563;7773;5562;5561;5560;5559;5558;5557;5556;5555;5554;5553;5552;5551;5550;5549;5548;5547;7774;5546;5545;5544;5543;5542;5541;5540;5539;5538;5537;5536;5535;5534;5533;5532;5531;7775;5530;5529;5528;5527;5526;5525;5524;5523;5522;5521;5520;5519;5518;5517;5516;7776;5515;5514;5513;5512;5511;5510;5509;5508;5507;5506;5505;5504;5503;5502;5501;5500;7777;5499;5498;5497;5496;5495;5494;5493;5492;5491;5490;5489;5488;5487;5486;5485;5484;7778;5483;5482;5481;5480;5479;5478;5477;5476;5475;5474;5473;5472;5471;5470;5469;5468;7779;5467;5466;5465;5464;5463;5462;5461;5460;5459;5458;5457;5456;5455;5454;5453;7780;5452;5451;5450;5449;5448;5447;5446;5445;5444;5443;5442;5441;5440;5439;5438;5437;7781;5436;5435;5434;5433;5432;5431;5430;5429;5428;5427;5426;5425;5424;5423;5422;5421;7782;5420;5419;5418;5417;5416;5415;5414;5413;5412;5411;5410;5409;5408;5407;5406;5405;7783;5404;5403;5402;5401;5400;5399;5398;5397;5396;5395;5394;5393;5392;5391;5390;5389;7784;5388;5387;5386;5385;5384;5383;5382;5381;5380;5379;5378;5377;5376;5375;5374;7785;5373;5372;5371;5370;5369;5368;5367;5366;5365;5364;5363;5362;5361;5360;5359;5358;7786;5357;5356;5355;5354;5353;5352;5351;5350;5349;5348;5347;5346;5345;5344;5343;5342;7787;5341;5340;5339;5338;5337;5336;5335;5334;5333;5332;5331;5330;5329;5328;5327;5326;7788;5325;5324;5323;5322;5321;5320;5319;5318;5317;5316;5315;5314;5313;5312;5311;7789;5310;5309;5308;5307;5306;5305;5304;5303;5302;5301;5300;5299;5298;5297;5296;5295;7790;5294;5293;5292;5291;5290;5289;5288;5287;5286;5285;5284;5283;5282;5281;5280;5279;7791;5278;5277;5276;5275;5274;5273;5272;5271;5270;5269;5268;5267;5266;5265;5264;5263;7792;5262;5261;5260;5259;5258;5257;5256;5255;5254;5253;5252;5251;5250;5249;5248;7793;5247;5246;5245;5244;5243;5242;5241;5240;5239;5238;5237;5236;5235;5234;5233;5232;7794;5231;5230;5229;5228;5227;5226;5225;5224;5223;5222;5221;5220;5219;5218;5217;5216;7795;5215;5214;5213;5212;5211;5210;5209;5208;5207;5206;5205;5204;5203;5202;5201;5200;7796;5199;5198;5197;5196;5195;5194;5193;5192;5191;5190;5189;5188;5187;5186;5185;5184;7797;5183;5182;5181;5180;5179;5178;5177;5176;5175;5174;5173;5172;5171;5170;5169;7798;5168;5167;5166;5165;5164;5163;5162;5161;5160;5159;5158;5157;5156;5155;5154;5153;7799;5152;5151;5150;5149;5148;5147;5146;5145;5144;5143;5142;5141;5140;5139;5138;5137;7800;5136;5135;5134;5133;5132;5131;5130;5129;5128;5127;5126;5125;5124;5123;5122;5121;7801;5120;5119;5118;5117;5116;5115;5114;5113;5112;5111;5110;5109;5108;5107;5106;7802;5105;5104;5103;5102;5101;5100;5099;5098;5097;5096;5095;5094;5093;5092;5091;5090;7803;5089;5088;5087;5086;5085;5084;5083;5082;5081;5080;5079;5078;5077;5076;5075;5074;7804;5073;5072;5071;5070;5069;5068;5067;5066;5065;5064;5063;5062;5061;5060;5059;5058;7805;5057;5056;5055;5054;5053;5052;5051;5050;5049;5048;5047;5046;5045;5044;5043;7806;5042;5041;5040;5039;5038;5037;5036;5035;5034;5033;5032;5031;5030;5029;5028;5027;7807;5026;5025;5024;5023;5022;5021;5020;5019;5018;5017;5016;5015;5014;5013;5012;5011;7808;5010;5009;5008;5007;5006;5005;5004;5003;5002;5001;5000;4999;4998;4997;4996;4995;7809;4994;4993;4992;4991;4990;4989;4988;4987;4986;4985;4984;4983;4982;4981;4980;4979;7810;4978;4977;4976;4975;4974;4973;4972;4971;4970;4969;4968;4967;4966;4965;4964;7811;4963;4962;4961;4960;4959;4958;4957;4956;4955;4954;4953;4952;4951;4950;4949;4948;7812;4947;4946;4945;4944;4943;4942;4941;4940;4939;4938;4937;4936;4935;4934;4933;4932;7813;4931;4930;4929;4928;4927;4926;4925;4924;4923;4922;4921;4920;4919;4918;4917;4916;7814;4915;4914;4913;4912;4911;4910;4909;4908;4907;4906;4905;4904;4903;4902;4901;7815;4900;4899;4898;4897;4896;4895;4894;4893;4892;4891;4890;4889;4888;4887;4886;4885;7816;4884;4883;4882;4881;4880;4879;4878;4877;4876;4875;4874;4873;4872;4871;4870;4869;7817;4868;4867;4866;4865;4864;4863;4862;4861;4860;4859;4858;4857;4856;4855;4854;4853;7818;4852;4851;4850;4849;4848;4847;4846;4845;4844;4843;4842;4841;4840;4839;4838;7819;4837;4836;4835;4834;4833;4832;4831;4830;4829;4828;4827;4826;4825;4824;4823;4822;7820;4821;4820;4819;4818;4817;4816;4815;4814;4813;4812;4811;4810;4809;4808;4807;4806;7821;4805;4804;4803;4802;4801;4800;4799;4798;4797;4796;4795;4794;4793;4792;4791;4790;7822;4789;4788;4787;4786;4785;4784;4783;4782;4781;4780;4779;4778;4777;4776;4775;4774;7823;4773;4772;4771;4770;4769;4768;4767;4766;4765;4764;4763;4762;4761;4760;4759;7824;4758;4757;4756;4755;4754;4753;4752;4751;4750;4749;4748;4747;4746;4745;4744;4743;7825;4742;4741;4740;4739;4738;4737;4736;4735;4734;4733;4732;4731;4730;4729;4728;4727;7826;4726;4725;4724;4723;4722;4721;4720;4719;4718;4717;4716;4715;4714;4713;4712;4711;7827;4710;4709;4708;4707;4706;4705;4704;4703;4702;4701;4700;4699;4698;4697;4696;7828;4695;4694;4693;4692;4691;4690;4689;4688;4687;4686;4685;4684;4683;4682;4681;4680;7829;4679;4678;4677;4676;4675;4674;4673;4672;4671;4670;4669;4668;4667;4666;4665;4664;7830;4663;4662;4661;4660;4659;4658;4657;4656;4655;4654;4653;4652;4651;4650;4649;4648;7831;4647;4646;4645;4644;4643;4642;4641;4640;4639;4638;4637;4636;4635;4634;4633;7832;4632;4631;4630;4629;4628;4627;4626;4625;4624;4623;4622;4621;4620;4619;4618;4617;7833;4616;4615;4614;4613;4612;4611;4610;4609;4608;4607;4606;4605;4604;4603;4602;4601;7834;4600;4599;4598;4597;4596;4595;4594;4593;4592;4591;4590;4589;4588;4587;4586;4585;7835;4584;4583;4582;4581;4580;4579;4578;4577;4576;4575;4574;4573;4572;4571;4570;4569;7836;4568;4567;4566;4565;4564;4563;4562;4561;4560;4559;4558;4557;4556;4555;4554;7837;4553;4552;4551;4550;4549;4548;4547;4546;4545;4544;4543;4542;4541;4540;4539;4538;7838;4537;4536;4535;4534;4533;4532;4531;4530;4529;4528;4527;4526;4525;4524;4523;4522;7839;4521;4520;4519;4518;4517;4516;4515;4514;4513;4512;4511;4510;4509;4508;4507;4506;7840;4505;4504;4503;4502;4501;4500;4499;4498;4497;4496;4495;4494;4493;4492;4491;7841;4490;4489;4488;4487;4486;4485;4484;4483;4482;4481;4480;4479;4478;4477;4476;4475;7842;4474;4473;4472;4471;4470;4469;4468;4467;4466;4465;4464;4463;4462;4461;4460;4459;7843;4458;4457;4456;4455;4454;4453;4452;4451;4450;4449;4448;4447;4446;4445;4444;4443;7844;4442;4441;4440;4439;4438;4437;4436;4435;4434;4433;4432;4431;4430;4429;4428;7845;4427;4426;4425;4424;4423;4422;4421;4420;4419;4418;4417;4416;4415;4414;4413;4412;7846;4411;4410;4409;4408;4407;4406;4405;4404;4403;4402;4401;4400;4399;4398;4397;4396;7847;4395;4394;4393;4392;4391;4390;4389;4388;4387;4386;4385;4384;4383;4382;4381;4380;7848;4379;4378;4377;4376;4375;4374;4373;4372;4371;4370;4369;4368;4367;4366;4365;4364;7849;4363;4362;4361;4360;4359;4358;4357;4356;4355;4354;4353;4352;4351;4350;4349;7850;4348;4347;4346;4345;4344;4343;1648;1647;1649;1650;1646;1651;1652;1653;1645;1654;1655;1644;1656;1657;1643;1658;1659;1660;1642;1661;1662;1641;1663;1664;1640;1665;1666;1667;1639;1668;1669;1638;1670;1671;1637;1672;1673;1674;1636;1675;1676;1635;1677;1678;1634;1679;1680;1681;1633;1682;1683;1632;1684;1685;1631;1686;1687;1688;1630;1689;1690;1629;1691;1692;1628;1693;1694;1695;1627;1696;1697;1626;1698;1699;1625;1700;1701;1702;1624;1703;1704;1623;1705;1706;1622;1707;1708;1709;1621;1710;1711;1620;1712;1713;1714;1619;1715;1716;1618;1717;1718;1617;1719;1720;1721;1616;1722;1723;1615;1724;1725;1614;1726;1727;1728;1613;1729;1730;1612;1731;1732;1611;1733;1734;1735;1610;1736;1737;1609;1738;1739;1608;1740;1741;1742;1607;1743;1744;1606;1745;1746;1605;1747;1748;1749;1604;1750;1751;1603;1752;1753;1602;1754;1755;1756;1601;1757;1758;1600;1759;1760;1599;1761;1762;1763;1598;1764;1765;1597;1766;1767;1596;1768;1769;1770;1595;1771;1772;1594;1773;1774;1593;1775;1776;1777;1592;1778;1779;1591;1780;1781;1590;1782;1783;1784;1589;1785;1786;1588;1787;1788;1587;1789;1790;1791;1586;1792;1793;1585;1794;1795;1796;1584;1797;1798;1583;1799;1800;1582;1801;1802;1803;1581;1804;1805;1580;1806;1807;1579;1808;1809;1810;1578;1811;1812;1577;1813;1814;1576;1815;1816;1817;1575;1818;1819;1574;1820;1821;1573;1822;1823;1824;1572;1825;1826;1571;1827;1828;1570;1829;1830;1831;1569;1832;1833;1568;1834;1835;1567;1836;1837;1838;1566;1839;1840;1565;1841;1842;1564;1843;1844;1845;1563;1846;1847;1562;1848;1849;1561;1850;1851;1852;1560;1853;1854;1559;1855;1856;1558;1857;1858;1859;1557;1860;1861;1556;1862;1863;1555;1864;1865;1866;1554;1867;1868;1553;1869;1870;1552;1871;1872;1873;1551;1874;1875;1550;1876;1877;1549;1878;1879;1880;1548;1881;1882;1547;1883;1884;1885;1546;1886;1887;1545;1888;1889;1544;1890;1891;1892;1543;1893;1894;1542;1895;1896;1541;1897;1898;1899;1540;1900;1901;1539;1902;1903;1538;1904;1905;1906;1537;1907;1908;1536;1909;1910;1535;1911;1912;1913;1534;1914;1915;1533;1916;1917;1532;1918;1919;1920;1531;1921;1922;1530;1923;1924;1529;1925;1926;1927;1528;1928;1929;1527;1930;1931;1526;1932;1933;1934;1525;1935;1936;1524;1937;1938;1523;1939;1940;1941;1522;1942;1943;1521;1944;1945;1520;1946;1947;1948;1519;1949;1950;1518;1951;1952;1517;1953;1954;1955;1516;1956;1957;1515;1958;1959;1514;1960;1961;1962;1513;1963;1964;1512;1965;1966;1967;1511;1968;1969;1510;1970;1971;1509;1972;1973;1974;1508;1975;1976;1507;1977;1978;1506;1979;1980;1981;1505;1982;1983;1504;1984;1985;1503;1986;1987;1988;1502;1989;1990;1501;1991;1992;1500;1993;1994;1995;1499;1996;1997;1498;1998;1999;1497;2000;2001;2002;1496;2003;2004;1495;2005;2006;1494;2007;2008;2009;1493;2010;2011;1492;2012;2013;1491;2014;2015;2016;1490;2017;2018;1489;2019;2020;1488;2021;2022;2023;1487;2024;2025;1486;2026;2027;1485;2028;2029;2030;1484;2031;2032;1483;2033;2034;1482;2035;2036;2037;1481;2038;2039;1480;2040;2041;1479;2042;2043;2044;1478;2045;2046;1477;2047;2048;2049;1476;2050;2051;1475;2052;2053;1474;2054;2055;2056;1473;2057;2058;1472;2059;2060;1471;2061;2062;2063;1470;2064;2065;1469;2066;2067;1468;2068;2069;2070;1467;2071;2072;1466;2073;2074;1465;2075;2076;2077;1464;2078;2079;1463;2080;2081;1462;2082;2083;2084;1461;2085;2086;1460;2087;2088;1459;2089;2090;2091;1458;2092;2093;1457;2094;2095;1456;2096;2097;2098;1455;2099;2100;1454;2101;2102;1453;2103;2104;2105;1452;2106;2107;1451;2108;2109;1450;2110;2111;2112;1449;2113;2114;1448;2115;2116;1447;2117;2118;2119;1446;2120;2121;1445;2122;2123;1444;2124;2125;2126;1443;2127;2128;1442;2129;2130;1441;2131;2132;2133;1440;2134;2135;1439;2136;2137;2138;1438;2139;2140;1437;2141;2142;1436;2143;2144;2145;1435;2146;2147;1434;2148;2149;1433;2150;2151;2152;1432;2153;2154;1431;2155;2156;1430;2157;2158;2159;1429;2160;2161;1428;2162;2163;1427;2164;2165;2166;1426;2167;2168;1425;2169;2170;1424;2171;2172;2173;1423;2174;2175;1422;2176;2177;1421;2178;2179;2180;1420;2181;2182;1419;2183;2184;1418;2185;2186;2187;1417;2188;2189;1416;2190;2191;1415;2192;2193;2194;1414;2195;2196;1413;2197;2198;1412;2199;2200;2201;1411;2202;2203;1410;2204;2205;1409;2206;2207;2208;1408;2209;2210;1407;2211;2212;1406;2213;2214;2215;1405;2216;2217;1404;2218;2219;2220;1403;2221;2222;1402;2223;2224;1401;2225;2226;2227;1400;2228;2229;1399;2230;2231;1398;2232;2233;2234;1397;2235;2236;1396;2237;2238;1395;2239;2240;2241;1394;2242;2243;1393;2244;2245;1392;2246;2247;2248;1391;2249;2250;1390;2251;2252;1389;2253;2254;2255;1388;2256;2257;1387;2258;2259;1386;2260;2261;2262;1385;2263;2264;1384;2265;2266;1383;2267;2268;2269;1382;2270;2271;1381;2272;2273;1380;2274;2275;2276;1379;2277;2278;1378;2279;2280;1377;2281;2282;2283;1376;2284;2285;1375;2286;2287;1374;2288;2289;2290;1373;2291;2292;1372;2293;2294;1371;2295;2296;2297;1370;2298;2299;1369;2300;2301;1368;2302;2303;2304;1367;2305;2306;1366;2307;2308;2309;1365;2310;2311;1364;2312;2313;1363;2314;2315;2316;1362;2317;2318;1361;2319;2320;1360;2321;2322;2323;1359;2324;2325;1358;2326;2327;1357;2328;2329;2330;1356;2331;2332;1355;2333;2334;1354;2335;2336;2337;1353;2338;2339;1352;2340;2341;1351;2342;2343;2344;1350;2345;2346;1349;2347;2348;1348;2349;2350;2351;1347;2352;2353;1346;2354;2355;1345;2356;2357;2358;1344;2359;2360;1343;2361;2362;1342;2363;2364;2365;1341;2366;2367;1340;2368;2369;1339;2370;2371;2372;1338;2373;2374;1337;2375;2376;1336;2377;2378;2379;1335;2380;2381;1334;2382;2383;1333;2384;2385;2386;1332;2387;2388;1331;2389;2390;2391;1330;2392;2393;1329;2394;2395;1328;2396;2397;2398;1327;2399;2400;1326;2401;2402;1325;2403;2404;2405;1324;2406;2407;1323;2408;2409;1322;2410;2411;2412;1321;2413;2414;1320;2415;2416;1319;2417;2418;2419;1318;2420;2421;1317;2422;2423;1316;2424;2425;2426;1315;2427;2428;1314;2429;2430;1313;2431;2432;2433;1312;2434;2435;1311;2436;2437;1310;2438;2439;2440;1309;2441;2442;1308;2443;2444;1307;2445;2446;2447;1306;2448;2449;1305;2450;2451;1304;2452;2453;2454;1303;2455;2456;1302;2457;2458;1301;2459;2460;2461;1300;2462;2463;1299;2464;2465;1298;2466;2467;2468;1297;2469;2470;1296;2471;2472;2473;1295;2474;2475;1294;2476;2477;1293;2478;2479;2480;1292;2481;2482;1291;2483;2484;1290;2485;2486;2487;1289;2488;2489;1288;2490;2491;1287;2492;2493;2494;1286;2495;2496;1285;2497;2498;1284;2499;2500;2501;1283;2502;2503;1282;2504;2505;1281;2506;2507;2508;1280;2509;2510;1279;2511;2512;1278;2513;2514;2515;1277;2516;2517;1276;2518;2519;1275;2520;2521;2522;1274;2523;2524;1273;2525;2526;1272;2527;2528;2529;1271;2530;2531;1270;2532;2533;1269;2534;2535;2536;1268;2537;2538;1267;2539;2540;1266;2541;2542;2543;1265;2544;2545;1264;2546;2547;1263;2548;2549;2550;1262;2551;2552;1261;2553;2554;1260;2555;2556;2557;1259;2558;2559;1258;2560;2561;2562;1257;2563;2564;1256;2565;2566;1255;2567;2568;2569;1254;2570;2571;1253;2572;2573;1252;2574;2575;2576;1251;2577;2578;1250;2579;2580;1249;2581;2582;2583;1248;2584;2585;1247;2586;2587;1246;2588;2589;2590;1245;2591;2592;1244;2593;2594;1243;2595;2596;2597;1242;2598;2599;1241;2600;2601;1240;2602;2603;2604;1239;2605;2606;1238;2607;2608;1237;2609;2610;2611;1236;2612;2613;1235;2614;2615;1234;2616;2617;2618;1233;2619;2620;1232;2621;2622;1231;2623;2624;2625;1230;2626;2627;1229;2628;2629;1228;2630;2631;2632;1227;2633;2634;1226;2635;2636;1225;2637;2638;2639;1224;2640;2641;1223;2642;2643;2644;1222;2645;2646;1221;2647;2648;1220;2649;2650;2651;1219;2652;2653;1218;2654;2655;1217;2656;2657;2658;1216;2659;2660;1215;2661;2662;1214;2663;2664;2665;1213;2666;2667;1212;2668;2669;1211;2670;2671;2672;1210;2673;2674;1209;2675;2676;1208;2677;2678;2679;1207;2680;2681;1206;2682;2683;1205;2684;2685;2686;1204;2687;2688;1203;2689;2690;1202;2691;2692;2693;1201;2694;2695;1200;2696;2697;1199;2698;2699;2700;1198;2701;2702;1197;2703;2704;1196;2705;2706;2707;1195;2708;2709;1194;2710;2711;1193;2712;2713;2714;1192;2715;2716;800;2717;2718;799;2719;2720;2721;798;2722;2723;797;2724;2725;361;360;362;363;364;365;366;367;368;359;369;370;371;372;373;374;358;375;376;377;378;379;380;357;381;382;383;384;385;386;387;356;388;389;390;391;392;393;355;394;395;396;397;398;399;400;354;401;402;403;404;405;406;353;407;408;409;410;411;412;352;413;414;415;416;417;418;419;351;420;421;422;423;424;425;350;426;427;428;429;430;431;349;432;433;434;435;436;437;438;348;439;440;441;442;443;444;347;445;446;447;448;449;450;451;346;452;453;454;455;456;457;345;458;459;460;461;462;463;344;464;465;466;467;468;469;470;343;471;472;473;474;475;476;342;477;478;479;480;481;482;483;341;484;485;486;487;488;489;340;490;491;492;493;494;495;339;496;497;498;499;500;501;502;338;503;504;505;506;507;508;337;509;510;511;512;513;514;336;515;516;517;518;519;520;521;335;522;523;524;525;526;527;334;528;529;530;531;532;533;534;333;535;536;537;538;539;540;332;541;542;543;544;545;546;331;547;548;549;550;551;552;553;330;554;555;556;557;558;559;329;560;561;562;563;564;565;328;566;567;568;569;570;571;572;327;573;574;575;576;577;578;326;579;580;581;582;583;584;585;325;586;587;588;589;590;591;324;592;593;594;595;596;597;323;598;599;600;601;602;603;604;322;605;606;607;608;609;610;321;611;612;613;614;615;616;320;617;618;619;620;621;622;623;319;624;625;626;627;628;629;318;630;631;632;633;634;635;636;317;637;638;639;640;641;642;316;643;644;645;646;647;648;315;649;650;651;652;653;654;655;314;656;657;658;659;660;661;313;662;663;664;665;666;667;312;668;669;670;671;672;673;674;311;675;676;677;678;679;680;310;681;682;683;684;685;686;687;309;688;689;690;691;692;693;308;694;695;696;697;698;699;307;700;701;702;703;704;705;706;306;707;708;709;710;711;712;305;713;714;715;716;717;718;304;719;720;721;722;723;724;725;303;726;727;728;729;730;731;302;732;733;734;735;736;737;738;301;739;740;741;742;743;744;300;745;746;747;748;749;750;299;751;752;753;754;755;756;757;298;758;759;760;761;762;763;297;764;765;766;767;768;769;296;770;771;772;773;774;775;776;295;777;778;779;780;781;782;294;783;784;785;786;787;788;789;293;790;791;792;793;794;795;292;796;2726;2727;2728;2729;2730;291;2731;2732;2733;2734;2735;2736;2737;290;2738;2739;2740;2741;2742;2743;289;2744;2745;2746;2747;2748;2749;288;2750;2751;2752;2753;2754;2755;2756;287;2757;2758;2759;2760;2761;2762;286;2763;2764;2765;2766;2767;2768;2769;285;2770;2771;2772;2773;2774;2775;284;2776;2777;2778;2779;2780;2781;283;2782;2783;2784;2785;2786;2787;2788;282;2789;2790;2791;2792;2793;2794;281;2795;2796;2797;2798;2799;2800;2801;280;2802;2803;2804;2805;2806;2807;279;2808;2809;2810;2811;2812;2813;278;2814;2815;2816;2817;2818;2819;2820;277;2821;2822;2823;2824;2825;2826;276;2827;2828;2829;2830;2831;2832;275;2833;2834;2835;2836;2837;2838;2839;274;2840;2841;2842;2843;2844;2845;273;2846;2847;2848;2849;2850;2851;2852;272;2853;2854;2855;2856;2857;2858;271;2859;2860;2861;2862;2863;2864;270;2865;2866;2867;2868;2869;2870;2871;269;2872;2873;2874;2875;2876;2877;268;2878;2879;2880;2881;2882;2883;267;2884;2885;2886;2887;2888;2889;2890;266;2891;2892;2893;2894;2895;2896;265;2897;2898;2899;2900;2901;2902;2903;264;2904;2905;2906;2907;2908;2909;263;2910;2911;2912;2913;2914;2915;262;2916;2917;2918;2919;2920;2921;2922;261;2923;2924;2925;2926;2927;2928;260;2929;2930;2931;2932;2933;2934;259;2935;2936;2937;2938;2939;2940;2941;258;2942;2943;2944;2945;2946;2947;257;2948;2949;2950;2951;2952;2953;2954;256;2955;2956;2957;2958;2959;2960;255;2961;2962;2963;2964;2965;2966;254;2967;2968;2969;2970;2971;2972;2973;253;2974;2975;2976;2977;2978;2979;252;2980;2981;2982;2983;2984;2985;251;2986;2987;2988;2989;2990;2991;2992;250;2993;2994;2995;2996;2997;2998;249;2999;3000;3001;3002;3003;3004;3005;248;3006;3007;3008;3009;3010;3011;247;3012;3013;3014;3015;3016;3017;246;3018;3019;3020;3021;3022;3023;3024;245;3025;3026;3027;3028;3029;3030;244;3031;3032;3033;3034;3035;3036;243;3037;3038;3039;3040;3041;3042;3043;242;3044;3045;3046;3047;3048;3049;241;3050;3051;3052;3053;3054;3055;3056;240;3057;3058;3059;3060;3061;3062;239;3063;3064;3065;3066;3067;3068;238;3069;3070;3071;3072;3073;3074;3075;237;3076;3077;3078;3079;3080;3081;236;3082;3083;3084;3085;3086;3087;235;3088;3089;3090;3091;3092;3093;3094;234;3095;3096;3097;3098;3099;3100;233;3101;3102;3103;3104;3105;3106;3107;232;3108;3109;3110;3111;3112;3113;231;3114;3115;3116;3117;3118;3119;230;3120;3121;3122;3123;3124;3125;3126;229;3127;3128;3129;3130;3131;3132;228;3133;3134;3135;3136;3137;3138;3139;227;3140;3141;3142;3143;3144;3145;226;3146;3147;3148;3149;3150;3151;225;3152;3153;3154;3155;3156;3157;3158;224;3159;3160;3161;3162;3163;3164;223;3165;3166;3167;3168;3169;3170;222;3171;3172;3173;3174;3175;3176;3177;221;3178;3179;3180;3181;3182;3183;220;3184;3185;3186;3187;3188;3189;3190;219;3191;3192;3193;3194;3195;3196;218;3197;3198;3199;3200;3201;3202;217;3203;3204;3205;3206;3207;3208;3209;216;3210;3211;3212;3213;3214;3215;215;3216;3217;3218;3219;3220;3221;214;3222;3223;3224;3225;3226;3227;3228;213;3229;3230;3231;3232;3233;3234;212;3235;3236;3237;3238;3239;3240;3241;211;3242;3243;3244;3245;3246;3247;210;3248;3249;3250;3251;3252;3253;209;3254;3255;3256;3257;3258;3259;3260;208;3261;3262;3263;3264;3265;3266;207;3267;3268;3269;3270;3271;3272;206;3273;3274;3275;3276;3277;3278;3279;205;3280;3281;3282;3283;3284;3285;204;3286;3287;3288;3289;3290;3291;3292;203;3293;3294;3295;3296;3297;3298;202;3299;3300;3301;3302;3303;3304;201;3305;3306;3307;3308;3309;3310;3311;200;3312;3313;3314;3315;3316;3317;199;3318;3319;3320;3321;3322;3323;198;3324;3325;3326;3327;3328;3329;3330;197;3331;3332;3333;3334;3335;3336;196;3337;3338;3339;3340;3341;3342;3343;195;3344;3345;3346;3347;3348;3349;194;3350;3351;3352;3353;3354;3355;193;3356;3357;3358;3359;3360;3361;3362;192;3363;3364;3365;3366;3367;3368;191;3369;3370;3371;3372;3373;3374;190;3375;3376;3377;3378;3379;3380;3381;189;3382;3383;3384;3385;3386;3387;188;3388;3389;3390;3391;3392;3393;3394;187;3395;3396;3397;3398;3399;3400;186;3401;3402;3403;3404;3405;3406;185;3407;3408;3409;3410;3411;3412;3413;184;3414;3415;3416;3417;3418;3419;183;3420;3421;3422;3423;3424;3425;182;3426;3427;3428;3429;3430;3431;3432;181;3433;3434;3435;3436;3437;3438;180;3439;3440;3441;3442;3443;3444;3445;179;3446;3447;3448;3449;3450;3451;178;3452;3453;3454;3455;3456;3457;177;3458;3459;3460;3461;3462;3463;3464;176;3465;3466;3467;3468;3469;3470;175;3471;3472;3473;3474;3475;3476;174;3477;3478;3479;3480;3481;3482;3483;173;3484;3485;3486;3487;3488;3489;172;3490;3491;3492;3493;3494;3495;3496;171;3497;3498;3499;3500;3501;3502;170;3503;3504;3505;3506;3507;3508;169;3509;3510;3511;3512;3513;3514;3515;168;3516;3517;3518;3519;3520;3521;167;3522;3523;3524;3525;3526;3527;3528;166;3529;3530;3531;3532;3533;3534;165;3535;3536;3537;3538;3539;3540;164;3541;3542;3543;3544;3545;3546;3547;163;3548;3549;3550;3551;3552;3553;162;3554;3555;3556;3557;3558;3559;161;3560;3561;3562;3563;3564;3565;3566;160;3567;3568;3569;3570;3571;3572;159;3573;3574;3575;3576;3577;3578;3579;158;3580;3581;3582;3583;3584;3585;157;3586;3587;3588;3589;3590;3591;156;3592;3593;3594;3595;3596;3597;3598;155;3599;3600;3601;3602;3603;3604;154;3605;3606;3607;3608;3609;3610;153;3611;3612;3613;3614;3615;3616;3617;152;3618;3619;3620;3621;3622;3623;151;3624;3625;3626;3627;3628;3629;3630;150;3631;3632;3633;3634;3635;3636;149;3637;3638;3639;3640;3641;3642;148;3643;3644;3645;3646;3647;3648;3649;147;3650;3651;3652;3653;3654;3655;146;3656;3657;3658;3659;3660;3661;145;3662;3663;3664;3665;3666;3667;3668;144;3669;3670;3671;3672;3673;3674;143;3675;3676;3677;3678;3679;3680;3681;142;3682;3683;3684;3685;3686;3687;141;3688;3689;3690;3691;3692;3693;140;3694;3695;3696;3697;3698;3699;3700;139;3701;3702;3703;3704;3705;3706;138;3707;3708;3709;3710;3711;3712;137;3713;3714;3715;3716;3717;3718;3719;136;3720;3721;3722;3723;3724;3725;135;3726;3727;3728;3729;3730;3731;3732;134;3733;3734;3735;3736;3737;3738;133;3739;3740;3741;3742;3743;3744;132;3745;3746;3747;3748;3749;3750;3751;131;3752;3753;3754;3755;3756;3757;130;3758;3759;3760;3761;3762;3763;129;3764;3765;3766;3767;3768;3769;3770;128;3771;3772;3773;3774;3775;3776;127;3777;3778;3779;3780;3781;3782;3783;126;3784;3785;3786;3787;3788;3789;125;3790;3791;3792;3793;3794;3795;124;3796;3797;3798;3799;3800;3801;3802;123;3803;3804;3805;3806;3807;3808;122;3809;3810;3811;3812;3813;3814;121;3815;3816;3817;3818;3819;3820;3821;120;3822;3823;3824;3825;3826;3827;119;3828;3829;3830;3831;3832;3833;3834;118;3835;3836;3837;3838;3839;3840;117;3841;3842;3843;3844;3845;3846;116;3847;3848;3849;3850;3851;3852;3853;115;3854;3855;3856;3857;3858;3859;114;3860;3861;3862;3863;3864;3865;3866;113;3867;3868;3869;3870;3871;3872;112;3873;3874;3875;3876;3877;3878;111;3879;3880;3881;3882;3883;3884;3885;110;3886;3887;3888;3889;3890;3891;109;3892;3893;3894;3895;3896;3897;108;3898;3899;3900;3901;3902;3903;3904;107;3905;3906;3907;3908;3909;3910;106;3911;3912;3913;3914;3915;3916;3917;105;3918;3919;3920;3921;3922;3923;104;3924;3925;3926;3927;3928;3929;103;3930;3931;3932;3933;3934;3935;3936;102;3937;3938;3939;3940;3941;3942;101;3943;3944;3945;3946;3947;3948;100;3949;3950;3951;3952;3953;3954;3955;99;3956;3957;3958;3959;3960;3961;98;3962;3963;3964;3965;3966;3967;3968;97;3969;3970;3971;3972;3973;3974;96;3975;3976;3977;3978;3979;3980;95;3981;3982;3983;3984;3985;3986;3987;94;3988;3989;3990;3991;3992;3993;93;3994;3995;3996;3997;3998;3999;92;4000;4001;4002;4003;4004;4005;4006;91;4007;4008;4009;4010;4011;4012;90;4013;4014;4015;4016;4017;4018;4019;89;4020;4021;4022;4023;4024;4025;88;4026;4027;4028;4029;4030;4031;87;4032;4033;4034;4035;4036;4037;4038;86;4039;4040;4041;4042;4043;4044;85;4045;4046;4047;4048;4049;4050;84;4051;4052;4053;4054;4055;4056;4057;83;4058;4059;4060;4061;4062;4063;82;4064;4065;4066;4067;4068;4069;4070;81;4071;4072;4073;4074;4075;4076;80;4077;4078;4079;4080;4081;4082;79;4083;4084;4085;4086;4087;4088;4089;78;4090;4091;4092;4093;4094;4095;77;4096;4097;4098;4099;4100;4101;76;4102;4103;4104;4105;4106;4107;4108;75;4109;4110;4111;4112;4113;4114;74;4115;4116;4117;4118;4119;4120;4121;73;4122;4123;4124;4125;4126;4127;72;4128;4129;4130;4131;4132;4133;71;4134;4135;4136;4137;4138;4139;4140;70;4141;4142;4143;4144;4145;4146;69;4147;4148;4149;4150;4151;4152;68;4153;4154;4155;4156;4157;4158;4159;67;4160;4161;4162;4163;4164;4165;66;4166;4167;4168;4169;4170;4171;4172;65;4173;4174;4175;4176;4177;4178;64;4179;4180;4181;4182;4183;4184;63;4185;4186;4187;4188;4189;4190;4191;62;4192;4193;4194;4195;4196;4197;61;4198;4199;4200;4201;4202;4203;60;4204;4205;4206;4207;4208;4209;4210;59;4211;4212;4213;4214;4215;4216;58;4217;4218;4219;4220;4221;4222;4223;57;4224;4225;4226;4227;4228;4229;56;4230;4231;4232;4233;4234;4235;55;4236;4237;4238;4239;4240;4241;4242;54;4243;4244;4245;4246;4247;4248;53;4249;4250;4251;4252;4253;4254;4255;52;4256;4257;4258;4259;4260;4261;51;4262;4263;4264;4265;4266;4267;50;4268;4269;4270;4271;4272;4273;4274;49;4275;4276;4277;4278;4279;4280;48;4281;4282;4283;4284;4285;4286;47;4287;4288;4289;4290;4291;4292;4293;46;4294;4295;4296;4297;4298;4299;45;4300;4301;4302;4303;4304;4305;4306;44;4307;4308;4309;4310;4311;4312;43;4313;4314;4315;4316;4317;4318;42;4319;4320;4321;4322;4323;4324;4325;41;4326;4327;4328;4329;7947;7946;7948;7945;7949;7944;7950;7943;7951;7942;7952;7941;7953;7940;7954;7939;7955;7938;7956;7937;7957;7936;7958;7935;7959;7934;7960;7933;7961;7932;7962;7931;7963;7930;7964;7929;7965;7928;7966;7967;7927;7968;7926;7969;7925;7970;7924;7971;7923;7972;7922;7973;7921;7974;7920;7975;7919;7976;7918;7977;7917;7978;7916;7979;7915;7980;7914;7981;7913;7982;7912;7983;7911;7984;7910;7985;7909;7986;7908;7987;7907;7988;7906;7989;7905;7990;7904;7991;7903;7992;7902;7993;7901;7994;7900;7995;7899;7996;7898;7997;7897;7998;7896;7999;7895;8000;7894;8001;7893;8002;7892;8003;7891;8004;7890;8005;7889;8006;7888;8007;7887;8008;7886;8009;7885;8010;7884;8011;8012;7883;8013;7882;8014;7881;8015;7880;8016;7879;8017;7878;8018;7877;8019;7876;8020;7875;8021;7874;8022;7873;8023;7872;8024;7871;8025;7870;8026;7869;8027;7868;8028;7867;8029;7866;8030;7865;8031;7864;8032;7863;8033;7862;8034;7861;8035;7860;8036;7859;8037;7858;8038;7857;8039;7856;8040;7855;8041;7854;8042;7853;8043;7852;8044;7851;8045;4342;8046;4341;8047;4340;8048;4339;8049;4338;8050;4337;8051;4336;8052;4335;8053;4334;8054;4333;8055;4332;8056;8057;4331;8058;4330;8059;40;8060;39;8061;38;8062;37;8063;36;8064;35;8065;34;8066;33;8067;32;8068;31;8069;30;8070;29;8071;28;8072;27;8073;26;8074;25;8075;24;8076;23;8077;22;8078;21;8079;20;8080;19;8081;18;8082;17;8083;16;8084;15;8085;14;8086;13;8087;12;8088;11;8089;10;8090;9;8091;8;8092;7;8093;6;8094;5;8095;4;8096;3;8097;2;8098;1;8099;0";
    }
}
