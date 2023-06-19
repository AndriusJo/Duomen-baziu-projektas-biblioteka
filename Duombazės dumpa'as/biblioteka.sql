-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 19, 2022 at 01:34 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `biblioteka`
--

-- --------------------------------------------------------

--
-- Table structure for table `autorius`
--

CREATE TABLE `autorius` (
  `autoriaus_kodas` varchar(10) NOT NULL,
  `vardas` varchar(30) NOT NULL,
  `pavarde` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `autorius`
--

INSERT INTO `autorius` (`autoriaus_kodas`, `vardas`, `pavarde`) VALUES
('1', 'Vardenis', 'Pavardenis'),
('BG843EU88S', 'Kibo', 'Spence'),
('BX764RU08D', 'Sydney', 'Blake'),
('CH556UB24U', 'Ferdinand', 'Shepard'),
('CR126PB68W', 'Elvis', 'Lane'),
('FR628TP84T', 'Chester', 'Buckley'),
('GO783BA28I', 'Bernard', 'Bowman'),
('IA442KO11Z', 'Philip', 'Vargas'),
('IF432PV72W', 'Lael', 'Humphrey'),
('LU181NW62K', 'Francis', 'Salazar'),
('PH681XU13R', 'Hasad', 'Roth'),
('QJ485CI84V', 'Blossom', 'Herman'),
('QO583JV15F', 'MacKenzie', 'Mays'),
('QX143TF44S', 'MacKensie', 'Guy'),
('RC552QU50M', 'Emma', 'Hogan'),
('RI365WC34J', 'Indigo', 'Golden'),
('RK753YC47U', 'Elaine', 'Castro'),
('SP735EW20Y', 'Sophia', 'Blevins'),
('SZ932KV87V', 'Rhonda', 'Whitfield'),
('TE563ZT48T', 'Cara', 'Ortega'),
('TI656MZ52F', 'Kelsie', 'Travis'),
('UD814GH36E', 'Nita', 'Christensen'),
('UX411XG15Z', 'Mohammad', 'Burris'),
('UZ304LI17U', 'Brent', 'Daugherty'),
('VN677TR34Q', 'Giacomo', 'Conley'),
('WS896QL11H', 'Lael', 'Chan');

-- --------------------------------------------------------

--
-- Table structure for table `darbuotojas`
--

CREATE TABLE `darbuotojas` (
  `darbuotojo_kodas` varchar(6) NOT NULL,
  `vardas` varchar(30) NOT NULL,
  `pavarde` varchar(30) NOT NULL,
  `stazas` int(11) DEFAULT NULL,
  `el_pastas` varchar(40) NOT NULL,
  `tel_nr` varchar(15) NOT NULL,
  `fk_FILIALASfil_kodas` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `darbuotojas`
--

INSERT INTO `darbuotojas` (`darbuotojo_kodas`, `vardas`, `pavarde`, `stazas`, `el_pastas`, `tel_nr`, `fk_FILIALASfil_kodas`) VALUES
('111', 'Vardenis', 'Pavardenis', 3, 'and@iki.com', '+28564885', 'K885Q'),
('ACM053', 'Leeroy', 'Hunt', 8, 'tempor@protonmail.edu', '1-649-957-2529', 'D322E'),
('CQY812', 'Silas', 'Little', 17, 'natoque.penatibus@yahoo.org', '1-441-125-1853', 'H421F'),
('EUK927', 'Lee', 'Fulton', 3, 'donec@aol.org', '1-864-696-5550', 'H421F'),
('FMP097', 'Lee', 'Prince', 14, 'duis.mi.enim@icloud.couk', '1-361-275-1840', 'E393B'),
('FWR231', 'Erasmus', 'Sampson', 0, 'varius.et@icloud.org', '1-821-515-7624', 'K162P'),
('GAY044', 'Gregory', 'Jimenez', 2, 'ut@icloud.com', '1-709-837-1575', 'Y739C'),
('GYY467', 'Oskar', 'Langley', 15, 'ac.fermentum.vel@google.org', '1-651-456-1118', 'J259K'),
('HBR859', 'Veronica', 'Holcomb', 8, 'faucibus@yahoo.org', '1-455-437-4642', 'H421F'),
('HIG417', 'Aileen', 'Buck', 19, 'proin.nisl@outlook.ca', '1-667-973-7228', 'D322E'),
('JMG222', 'Alana', 'Faulkner', 3, 'montes.nascetur@yahoo.net', '1-568-253-5271', 'D322E'),
('JWO538', 'Montana', 'Berg', 7, 'adipiscing.ligula.aenean@icloud.com', '1-631-830-6655', 'J259K'),
('KDB736', 'Bell', 'Combs', 16, 'non.nisi@outlook.org', '1-224-545-6244', 'D545J'),
('KXJ344', 'Ulric', 'Rogers', 16, 'a.magna@icloud.edu', '1-228-874-8281', 'K162P'),
('MUR461', 'Curran', 'Trevino', 9, 'mauris.quis@protonmail.net', '1-797-674-2441', 'I990L'),
('NIV433', 'Brent', 'Bates', 1, 'malesuada@protonmail.com', '1-767-412-4933', 'E393B'),
('NIY374', 'Rama', 'Montoya', 9, 'blandit.mattis@outlook.net', '1-593-818-6353', 'Y739C'),
('NNG736', 'Rowan', 'Gillespie', 10, 'libero.et.tristique@icloud.couk', '1-911-310-0063', 'D318A'),
('NWF718', 'Amery', 'Copeland', 4, 'mus.donec@outlook.edu', '1-136-714-2407', 'D318A'),
('NYE759', 'Iliana', 'Phillips', 12, 'tristique.pellentesque.tellus@google.edu', '1-339-316-1527', 'D318A'),
('ODF464', 'Evangeline', 'Wolf', 13, 'proin.nisl.sem@protonmail.couk', '1-382-832-5775', 'K885Q'),
('OHL060', 'Lael', 'Roth', 6, 'dui.cum@icloud.net', '1-437-367-1853', 'D545J'),
('QPU821', 'Kasper', 'Peters', 15, 'velit.in@protonmail.couk', '1-532-167-3228', 'H421F'),
('RPN361', 'Emily', 'Barrett', 17, 'vivamus.rhoncus@hotmail.ca', '1-244-455-5385', 'J259K'),
('SBI315', 'Tate', 'Buchanan', 13, 'neque@yahoo.org', '1-623-417-9586', 'E393B'),
('TRP587', 'Joy', 'Riley', 18, 'aliquam@icloud.edu', '1-447-664-3332', 'H421F'),
('VWQ818', 'Russell', 'Kim', 16, 'tellus.justo@icloud.org', '1-741-153-5727', 'I990L'),
('WMX531', 'Susan', 'Franks', 17, 'sem.mollis@protonmail.org', '1-545-867-4196', 'D545J'),
('XSI682', 'Robin', 'Ross', 9, 'mauris.integer.sem@outlook.org', '1-469-115-6775', 'D322E'),
('YHC846', 'Callum', 'Wood', 4, 'morbi.metus@google.couk', '1-511-684-1708', 'H421F'),
('ZQX800', 'Sheila', 'Richard', 11, 'neque.vitae@hotmail.org', '1-823-621-1384', 'K162P');

-- --------------------------------------------------------

--
-- Table structure for table `delsimas`
--

CREATE TABLE `delsimas` (
  `dienu_skaicius` int(11) NOT NULL,
  `skolos_suma` float NOT NULL,
  `fk_uzsakymo_nr` varchar(9) NOT NULL,
  `fk_skaitytojo_kodas` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `delsimas`
--

INSERT INTO `delsimas` (`dienu_skaicius`, `skolos_suma`, `fk_uzsakymo_nr`, `fk_skaitytojo_kodas`) VALUES
(5, 0.5, '100000004', 'AF863228'),
(16, 1.6, '100000006', 'GA819458');

-- --------------------------------------------------------

--
-- Table structure for table `filialas`
--

CREATE TABLE `filialas` (
  `fil_kodas` varchar(5) NOT NULL,
  `miestas` varchar(20) NOT NULL,
  `el_pastas` varchar(40) NOT NULL,
  `tel_nr` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `filialas`
--

INSERT INTO `filialas` (`fil_kodas`, `miestas`, `el_pastas`, `tel_nr`) VALUES
('D318A', 'Tra Vinh', 'inceptos.hymenaeos@hotmail.net', '1-604-624-3741'),
('D322E', 'Kalisz', 'ligula.donec@yahoo.org', '1-796-748-8117'),
('D545J', 'Rio Ibanez', 'morbi.tristique.senectus@hotmail.org', '1-801-645-1472'),
('E393B', 'Stevoort', 'suspendisse.commodo.tincidunt@outlook.or', '1-832-658-7554'),
('H421F', 'Melilla', 'nulla.ante@aol.net', '1-471-683-4678'),
('I990L', 'Paulista', 'donec.nibh.quisque@google.ca', '1-683-732-7585'),
('J259K', 'Tire', 'suspendisse.dui.fusce@icloud.com', '1-358-832-1275'),
('K162P', 'Dijon', 'sollicitudin.adipiscing.ligula@google.ed', '1-387-109-7067'),
('K885Q', 'Vinh Yen', 'non.magna.nam@outlook.ca', '1-421-744-5671'),
('Y739C', 'San Francisco', 'mus.proin.vel@google.com', '1-897-632-2583');

-- --------------------------------------------------------

--
-- Table structure for table `knyga`
--

CREATE TABLE `knyga` (
  `bruksninis_kodas` varchar(30) NOT NULL,
  `puslapiu_kiekis` int(11) NOT NULL,
  `kalba` varchar(20) NOT NULL,
  `pavadinimas` varchar(50) NOT NULL,
  `viso_kopiju` int(11) NOT NULL,
  `turima_kopiju` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `knyga`
--

INSERT INTO `knyga` (`bruksninis_kodas`, `puslapiu_kiekis`, `kalba`, `pavadinimas`, `viso_kopiju`, `turima_kopiju`) VALUES
('018-87-74062-81-7', 437, 'Italian', 'The Metamorphosis', 3, 0),
('048-65-67054-77-0', 416, 'Czech', 'Paradise Lost', 4, 0),
('050-40-55014-04-5', 400, 'Assamese', 'Tristram Shandy', 1, 0),
('085-80-86504-81-3', 212, 'Bhojpuri', 'Nineteen Eighty Four', 4, 0),
('1', 0, 'anglu', 'Gynimas', 0, 0),
('135-85-58875-61-0', 114, 'Bengali', 'Robinson Crusoe', 4, 0),
('178-46-66207-23-5', 205, 'Uzbek', 'Tess of the d\'Urbervilles', 4, 0),
('275-58-41703-53-1', 284, 'Vietnamese', 'Ulysses', 3, 0),
('3', 0, 'anglu', 'Gynimas3', 0, 0),
('307-04-81325-86-4', 484, 'Italian', 'Madame Bovary', 2, 0),
('332-45-67847-56-6', 318, 'Bhojpuri', 'The Magic Mountain', 3, 0),
('405-62-25681-73-3', 343, 'Uzbek', 'To Kill a Mockingbird', 3, 0),
('456-72-65861-78-8', 510, 'Fula', 'The Grapes of Wrath', 4, 0),
('470-87-62346-27-7', 510, 'Sindhi', 'The Great Gatsby', 2, 0),
('476-23-22751-13-5', 477, 'Fula', 'The Good Soldier', 3, 0),
('524-65-55777-05-6', 559, 'German', 'The Sun Also Rises', 1, 0),
('564-32-88055-73-3', 496, 'Uyghur', 'Game of Thrones', 3, 0),
('572-24-11762-63-7', 453, 'Amharic', 'Pride and Prejudice', 3, 0),
('601-01-71535-04-2', 589, 'Somali', 'Ulysses', 3, 0),
('611-81-43072-23-4', 222, 'Turkish', 'The Handmaid\'s Tale', 3, 0),
('614-27-66126-77-7', 141, 'Belarusian', 'The Divine Comedy', 3, 0),
('614-57-43115-05-6', 502, 'Yue', 'The Great Gatsby', 1, 0),
('655-76-08173-70-1', 550, 'Tamil', 'Emma', 1, 0),
('740-55-65780-15-7', 532, 'German', 'The Magic Mountain', 3, 0),
('814-07-44010-17-7', 245, 'Ukrainian', 'The Handmaid\'s Tale', 3, 0),
('822-44-41463-50-4', 264, 'Assamese', 'Vanity Fair', 2, 0),
('853-64-03388-48-7', 553, 'Dutch', 'The Good Soldier', 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `kopija`
--

CREATE TABLE `kopija` (
  `nr` int(11) NOT NULL,
  `leidejas` varchar(30) NOT NULL,
  `leidimo_metai` date NOT NULL,
  `busena` varchar(25) NOT NULL,
  `fk_KNYGAbruksninis_kodas` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `kopija`
--

INSERT INTO `kopija` (`nr`, `leidejas`, `leidimo_metai`, `busena`, `fk_KNYGAbruksninis_kodas`) VALUES
(1, 'Cras Eget Ltd', '1992-04-11', 'Gera', '853-64-03388-48-7'),
(2, 'Ut LLC', '1982-08-05', 'Gera', '822-44-41463-50-4'),
(3, 'Nunc Lectus Institute', '1963-07-23', 'Gera', '822-44-41463-50-4'),
(4, 'At Velit Company', '1935-04-23', 'Gera', '018-87-74062-81-7'),
(5, 'Sed Hendrerit Institute', '1983-02-27', 'Gera', '018-87-74062-81-7'),
(6, 'Tempus Risus Consulting', '1944-11-19', 'Gera', '018-87-74062-81-7'),
(7, 'Quis Arcu Incorporated', '1933-03-24', 'Gera', '048-65-67054-77-0'),
(8, 'Libero Dui Foundation', '1945-05-13', 'Gera', '048-65-67054-77-0'),
(9, 'Fames Ac Turpis LLC', '1963-12-17', 'Gera', '048-65-67054-77-0'),
(10, 'Montes Nascetur LLC', '1986-08-06', 'Gera', '048-65-67054-77-0'),
(11, 'Amet Ornare Lectus PC', '1959-06-11', 'Gera', '050-40-55014-04-5'),
(12, 'Nunc Quisque Associates', '2008-02-07', 'Gera', '085-80-86504-81-3'),
(13, 'Fermentum Arcu Ltd', '1932-10-06', 'Gera', '085-80-86504-81-3'),
(14, 'Nunc Laoreet Lectus Ltd', '1989-05-04', 'Gera', '085-80-86504-81-3'),
(15, 'Fusce Aliquam LLC', '1940-12-28', 'Gera', '085-80-86504-81-3'),
(16, 'Auctor Odio A Ltd', '1990-06-23', 'Gera', '135-85-58875-61-0'),
(17, 'Non PC', '1934-06-18', 'Gera', '135-85-58875-61-0'),
(18, 'Scelerisque Sed Sapien Inc.', '1952-08-02', 'Gera', '135-85-58875-61-0'),
(19, 'Arcu Morbi PC', '2000-08-18', 'Gera', '135-85-58875-61-0'),
(20, 'Non Enim Inc.', '1963-08-05', 'Gera', '178-46-66207-23-5'),
(21, 'Et Magnis Company', '1955-04-11', 'Gera', '178-46-66207-23-5'),
(22, 'Lacus Nulla Consulting', '1940-11-25', 'Gera', '178-46-66207-23-5'),
(23, 'Interdum Corp.', '1934-05-16', 'Gera', '178-46-66207-23-5'),
(24, 'Fusce LLP', '2016-04-27', 'Gera', '275-58-41703-53-1'),
(25, 'Senectus Et Corp.', '1986-03-02', 'Gera', '275-58-41703-53-1'),
(26, 'Libero Morbi Accumsan Corporat', '1968-04-06', 'Gera', '275-58-41703-53-1'),
(27, 'Elit Dictum Associates', '2008-11-26', 'Gera', '307-04-81325-86-4'),
(28, 'Non LLP', '2018-09-29', 'Gera', '307-04-81325-86-4'),
(29, 'Id Erat Etiam Institute', '1954-12-27', 'Gera', '332-45-67847-56-6'),
(30, 'Nisl Limited', '1949-11-25', 'Gera', '332-45-67847-56-6'),
(31, 'Dui Nec Industries', '1942-06-21', 'Gera', '332-45-67847-56-6'),
(32, 'Sem Molestie Ltd', '1984-10-04', 'Gera', '405-62-25681-73-3'),
(33, 'Curabitur Sed LLC', '1933-11-24', 'Gera', '405-62-25681-73-3'),
(34, 'Sociis Natoque Institute', '1972-11-16', 'Gera', '405-62-25681-73-3'),
(35, 'Aliquet Metus Ltd', '2016-05-22', 'Gera', '456-72-65861-78-8'),
(36, 'Curae Donec Tincidunt Ltd', '2000-09-13', 'Gera', '456-72-65861-78-8'),
(37, 'Orci Ut Semper Corp.', '1956-02-21', 'Gera', '456-72-65861-78-8'),
(38, 'Bibendum Corp.', '1947-12-04', 'Gera', '456-72-65861-78-8'),
(39, 'Dapibus Corp.', '2019-02-23', 'Gera', '470-87-62346-27-7'),
(40, 'Facilisis Lorem Corporation', '2003-06-26', 'Gera', '470-87-62346-27-7'),
(41, 'Eu PC', '1962-04-20', 'Gera', '476-23-22751-13-5'),
(42, 'Lectus Sit Institute', '1971-06-02', 'Gera', '476-23-22751-13-5'),
(43, 'Lacus Quisque LLC', '1958-08-13', 'Gera', '476-23-22751-13-5'),
(44, 'Rutrum Justo Praesent Corporat', '1948-07-23', 'Gera', '524-65-55777-05-6'),
(45, 'Molestie Sed Id Incorporated', '1962-07-30', 'Gera', '564-32-88055-73-3'),
(46, 'Ridiculus Mus Limited', '2001-10-21', 'Gera', '564-32-88055-73-3'),
(47, 'Faucibus Leo Limited', '1943-09-20', 'Gera', '564-32-88055-73-3'),
(48, 'Orci Ut Sagittis Corporation', '2007-04-11', 'Gera', '572-24-11762-63-7'),
(49, 'Inceptos Hymenaeos Mauris Corp', '2010-11-07', 'Gera', '572-24-11762-63-7'),
(50, 'Mi Lorem Incorporated', '1991-06-09', 'Gera', '572-24-11762-63-7'),
(51, 'Est Associates', '1962-08-18', 'Gera', '611-81-43072-23-4'),
(52, 'Sociis Industries', '1941-08-31', 'Gera', '611-81-43072-23-4'),
(53, 'Vitae Orci Ltd', '1990-11-21', 'Gera', '611-81-43072-23-4'),
(54, 'Eu Tempor Inc.', '1956-06-30', 'Gera', '614-27-66126-77-7'),
(55, 'Molestie Ltd', '1965-09-29', 'Gera', '614-27-66126-77-7'),
(56, 'Dapibus Id Associates', '1967-03-23', 'Gera', '614-27-66126-77-7'),
(57, 'Sed Diam Corp.', '1954-06-24', 'Gera', '614-57-43115-05-6'),
(58, 'Dis Parturient Corporation', '1937-08-29', 'Gera', '655-76-08173-70-1'),
(59, 'Neque Morbi Institute', '1960-03-30', 'Gera', '601-01-71535-04-2'),
(60, 'Accumsan Laoreet Industries', '2013-10-31', 'Gera', '601-01-71535-04-2'),
(61, 'Orci Ut Sagittis Ltd', '1989-02-23', 'Gera', '601-01-71535-04-2'),
(62, 'Mauris Blandit LLP', '1985-05-29', 'Gera', '740-55-65780-15-7'),
(63, 'Ullamcorper Velit Associates', '1946-03-27', 'Gera', '740-55-65780-15-7'),
(64, 'Sit Amet LLP', '1942-06-11', 'Gera', '740-55-65780-15-7'),
(65, 'Magna PC', '1933-04-28', 'Gera', '814-07-44010-17-7'),
(66, 'Gravida Nunc Sed PC', '1993-08-26', 'Gera', '814-07-44010-17-7'),
(67, 'Molestie Pharetra LLP', '1979-11-18', 'Gera', '814-07-44010-17-7');

-- --------------------------------------------------------

--
-- Table structure for table `mokejimas`
--

CREATE TABLE `mokejimas` (
  `data` date NOT NULL,
  `suma` float NOT NULL,
  `fk_SASKAITAsaskaitos_numeris` int(11) NOT NULL,
  `fk_SKAITYTOJASskaitytojo_kodas` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mokejimas`
--

INSERT INTO `mokejimas` (`data`, `suma`, `fk_SASKAITAsaskaitos_numeris`, `fk_SKAITYTOJASskaitytojo_kodas`) VALUES
('2022-03-08', 1.6, 1000000002, 'GA819458');

-- --------------------------------------------------------

--
-- Table structure for table `parase`
--

CREATE TABLE `parase` (
  `fk_AUTORIUSautoriaus_kodas` varchar(10) NOT NULL,
  `fk_KNYGAbruksninis_kodas` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `parase`
--

INSERT INTO `parase` (`fk_AUTORIUSautoriaus_kodas`, `fk_KNYGAbruksninis_kodas`) VALUES
('1', '1'),
('1', '3'),
('BG843EU88S', '018-87-74062-81-7'),
('BX764RU08D', '048-65-67054-77-0'),
('CH556UB24U', '050-40-55014-04-5'),
('CR126PB68W', '085-80-86504-81-3'),
('FR628TP84T', '135-85-58875-61-0'),
('GO783BA28I', '178-46-66207-23-5'),
('IA442KO11Z', '275-58-41703-53-1'),
('IF432PV72W', '307-04-81325-86-4'),
('LU181NW62K', '332-45-67847-56-6'),
('PH681XU13R', '405-62-25681-73-3'),
('QJ485CI84V', '456-72-65861-78-8'),
('QO583JV15F', '470-87-62346-27-7'),
('QX143TF44S', '476-23-22751-13-5'),
('RC552QU50M', '524-65-55777-05-6'),
('RI365WC34J', '564-32-88055-73-3'),
('RK753YC47U', '572-24-11762-63-7'),
('SP735EW20Y', '614-57-43115-05-6'),
('SZ932KV87V', '611-81-43072-23-4'),
('TE563ZT48T', '614-27-66126-77-7'),
('TI656MZ52F', '655-76-08173-70-1'),
('UD814GH36E', '740-55-65780-15-7'),
('UX411XG15Z', '814-07-44010-17-7'),
('UZ304LI17U', '822-44-41463-50-4'),
('VN677TR34Q', '853-64-03388-48-7'),
('WS896QL11H', '601-01-71535-04-2');

-- --------------------------------------------------------

--
-- Table structure for table `priklauso`
--

CREATE TABLE `priklauso` (
  `fk_ZANRASpavadinimas` varchar(30) NOT NULL,
  `fk_KNYGAbruksninis_kodas` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `priklauso`
--

INSERT INTO `priklauso` (`fk_ZANRASpavadinimas`, `fk_KNYGAbruksninis_kodas`) VALUES
('Action', '018-87-74062-81-7'),
('Animation', '3'),
('Art', '085-80-86504-81-3'),
('Art', '470-87-62346-27-7'),
('Autobiography', '614-57-43115-05-6'),
('Biography', '178-46-66207-23-5'),
('Comedy', '050-40-55014-04-5'),
('Family', '740-55-65780-15-7'),
('Fantasy', '814-07-44010-17-7'),
('Food and Drink', '822-44-41463-50-4'),
('Graphic Novel', '048-65-67054-77-0'),
('Guide/How-to', '655-76-08173-70-1'),
('Horror', '405-62-25681-73-3'),
('LGBTQ+', '307-04-81325-86-4'),
('LGBTQ+', '456-72-65861-78-8'),
('Memoir', '332-45-67847-56-6'),
('Musical', '275-58-41703-53-1'),
('Mystery', '564-32-88055-73-3'),
('Parenting and Family', '853-64-03388-48-7'),
('Photography', '572-24-11762-63-7'),
('Religion', '614-27-66126-77-7'),
('Science', '524-65-55777-05-6'),
('Self-help', '476-23-22751-13-5'),
('Spirituality', '135-85-58875-61-0'),
('Travel', '1'),
('Travel', '611-81-43072-23-4'),
('True Crime', '601-01-71535-04-2');

-- --------------------------------------------------------

--
-- Table structure for table `registracija`
--

CREATE TABLE `registracija` (
  `data` date NOT NULL,
  `fk_SKAITYTOJASskaitytojo_kodas` varchar(8) NOT NULL,
  `fk_FILIALASfil_kodas` varchar(5) NOT NULL,
  `fk_DARBUOTOJASdarbuotojo_kodas` varchar(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `registracija`
--

INSERT INTO `registracija` (`data`, `fk_SKAITYTOJASskaitytojo_kodas`, `fk_FILIALASfil_kodas`, `fk_DARBUOTOJASdarbuotojo_kodas`) VALUES
('2009-04-03', 'AF863228', 'Y739C', 'NIY374'),
('2011-07-27', 'BK539762', 'Y739C', 'NIY374'),
('2019-11-09', 'BL888448', 'J259K', 'RPN361'),
('2011-07-27', 'BS513261', 'D322E', 'XSI682'),
('2010-03-31', 'CF272375', 'H421F', 'YHC846'),
('2015-06-19', 'CN507552', 'K885Q', 'ODF464'),
('2018-10-05', 'DJ019641', 'K162P', 'ZQX800'),
('2019-04-30', 'EZ318595', 'I990L', 'VWQ818'),
('2012-08-01', 'FM274967', 'E393B', 'SBI315'),
('2016-09-01', 'FZ880434', 'K162P', 'FWR231'),
('2019-11-17', 'GA819458', 'I990L', 'MUR461'),
('2011-03-19', 'HB644163', 'H421F', 'ACM053'),
('2016-09-18', 'JT814134', 'D322E', 'JMG222'),
('2019-04-12', 'JX334468', 'D322E', 'HIG417'),
('2014-01-01', 'KL213792', 'D545J', 'OHL060'),
('2017-08-11', 'LE130145', 'D545J', 'KDB736'),
('2010-05-19', 'LO407394', 'E393B', 'NIV433'),
('2013-07-04', 'ML760400', 'E393B', 'FMP097'),
('2013-06-28', 'MP550316', 'J259K', 'GYY467'),
('2017-05-04', 'NC563532', 'J259K', 'JWO538'),
('2006-02-06', 'PM988691', 'H421F', 'EUK927'),
('2018-11-22', 'RD220023', 'H421F', 'EUK927'),
('2021-02-11', 'RN645205', 'H421F', 'ACM053'),
('2022-02-19', 'RW882273', 'H421F', 'YHC846'),
('2009-03-21', 'SJ551520', 'Y739C', 'NIY374'),
('2012-03-18', 'SV544669', 'Y739C', 'GAY044'),
('2019-12-27', 'UC008723', 'K162P', 'FWR231'),
('2020-07-24', 'UJ175101', 'K162P', 'ZQX800'),
('2012-12-30', 'VG763973', 'K162P', 'KXJ344'),
('2007-05-31', 'ZD060311', 'K885Q', 'ODF464');

-- --------------------------------------------------------

--
-- Table structure for table `saskaita`
--

CREATE TABLE `saskaita` (
  `saskaitos_numeris` int(11) NOT NULL,
  `data` date NOT NULL,
  `busena` varchar(25) NOT NULL,
  `fk_DELSIMAS_skolos_suma` float NOT NULL,
  `fk_UZSAKYMAS_uzsakymo_nr` varchar(9) NOT NULL,
  `fk_SKAITYTOJAS_skaitytojo_kodas` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `saskaita`
--

INSERT INTO `saskaita` (`saskaitos_numeris`, `data`, `busena`, `fk_DELSIMAS_skolos_suma`, `fk_UZSAKYMAS_uzsakymo_nr`, `fk_SKAITYTOJAS_skaitytojo_kodas`) VALUES
(1000000001, '2022-03-08', 'Neapmokėta', 0.5, '100000004', 'AF863228'),
(1000000002, '2022-03-08', 'Apmokėta', 1.6, '100000006', 'GA819458');

-- --------------------------------------------------------

--
-- Table structure for table `skaitytojas`
--

CREATE TABLE `skaitytojas` (
  `skaitytojo_kodas` varchar(8) NOT NULL,
  `vardas` varchar(30) NOT NULL,
  `pavarde` varchar(30) NOT NULL,
  `elektroninis_pastas` varchar(40) NOT NULL,
  `tel_nr` varchar(15) DEFAULT NULL,
  `adresas` varchar(50) DEFAULT NULL,
  `banko_saskaita` varchar(34) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `skaitytojas`
--

INSERT INTO `skaitytojas` (`skaitytojo_kodas`, `vardas`, `pavarde`, `elektroninis_pastas`, `tel_nr`, `adresas`, `banko_saskaita`) VALUES
('AF863228', 'Dilan', 'Pavardee', 'nec.malesuada.ut@hotmail.com', '1-786-647-7188', 'P.O. Box 968, 5926 Nec, Rd.', 'MU9821366428074527926461066669'),
('BK539762', 'Diana', 'Hubbard', 'arcu.curabitur@outlook.ca', '1-412-552-5294', '835-5265 Ac St.', 'GT53835885395827439142873244'),
('BL888448', 'Rhona', 'Ortega', 'maecenas.libero.est@outlook.com', '1-701-471-2155', '465-9231 Neque Street', 'SA8555373462713772905265'),
('BS513261', 'Kane', 'Wilkinson', 'ut@hotmail.couk', '1-991-767-2740', 'P.O. Box 624, 6356 Bibendum Street', 'TN3424764211268526857778'),
('CF272375', 'Marah', 'Reyes', 'fringilla.porttitor@google.ca', '1-720-235-8678', '1231 Arcu. Rd.', 'AL03154237516427766257891847'),
('CN507552', 'MacKensie', 'Vinson', 'arcu.aliquam@outlook.com', '1-841-187-1436', 'Ap #856-1038 Ligula. Rd.', 'PS801002654751584174833285551'),
('DJ019641', 'Daryl', 'Winters', 'nisi@protonmail.ca', '1-571-190-8799', '8571 Aliquet, Avenue', 'IT467VWAAI32445120861763865'),
('EZ318595', 'Solomon', 'Brewer', 'sit.amet@protonmail.ca', '1-216-528-7638', 'Ap #384-2130 Tincidunt Road', 'NO4249897803428'),
('FM274967', 'Beau', 'Randolph', 'quisque@google.org', '1-560-853-3692', 'Ap #417-918 Libero. Avenue', 'IS581575525935186645328580'),
('FZ880434', 'Odessa', 'Castaneda', 'litora.torquent@yahoo.couk', '1-611-168-5532', '9453 Elit, Av.', 'BG48VGUJ72795478111124'),
('GA819458', 'Brock', 'Hale', 'ipsum@hotmail.org', '1-429-120-7655', '753-6198 Vulputate, Avenue', 'KW5042768491281334218054301665'),
('HB644163', 'Charity', 'Mcclure', 'ut.aliquam@google.com', '1-851-177-3212', 'Ap #782-1369 Odio Avenue', 'HU90808208804658112971076244'),
('JT814134', 'Harding', 'Stevenson', 'enim.gravida.sit@aol.net', '1-193-736-1513', '718-8790 Malesuada Rd.', 'MD6568540052016132640984'),
('JX334468', 'Armand', 'Banks', 'convallis@google.edu', '1-665-718-0451', 'Ap #438-8614 Sodales Avenue', 'CH2044368542078176654'),
('KL213792', 'Juliet', 'Lewis', 'enim.curabitur@icloud.com', '1-778-518-0644', 'Ap #712-3925 Sit Rd.', 'PS755448145154656543226140616'),
('LE130145', 'Devin', 'Avila', 'orci@yahoo.net', '1-422-625-7184', '370-5817 Pellentesque Rd.', 'CZ4161773658034972867454'),
('LO407394', 'Aline', 'Silva', 'sem.egestas@outlook.ca', '1-902-288-2728', '753-4400 Ipsum Street', 'SM9657367978268213128577394'),
('ML760400', 'Rajah', 'Harrington', 'integer@icloud.couk', '1-412-827-7335', 'P.O. Box 278, 3974 Ac, Rd.', 'SE7141445758664424022592'),
('MP550316', 'Darrel', 'Barber', 'bibendum.sed@hotmail.edu', '1-452-262-3920', 'P.O. Box 567, 827 Malesuada Ave', 'GE76824637541136785163'),
('NC563532', 'Allistair', 'Albert', 'ac.libero@icloud.ca', '1-754-489-1972', '710-575 At Rd.', 'TN6422767367251768623626'),
('PM988691', 'Oprah', 'Hill', 'praesent.interdum@outlook.ca', '1-391-253-2341', 'Ap #570-7075 Gravida Road', 'ES4812627376584688324310'),
('RD220023', 'Echo', 'Hunter', 'amet.diam.eu@aol.couk', '1-561-276-2809', 'Ap #759-7631 Eget, Ave', 'RS70789760341471835762'),
('RN645205', 'Pamela', 'Kirk', 'sed.congue.elit@hotmail.ca', '1-545-218-4279', 'P.O. Box 101, 3804 Donec Ave', 'BE76367292565413'),
('RW882273', 'Camilla', 'Marks', 'ante.maecenas.mi@yahoo.com', '1-844-638-2148', 'Ap #708-3393 Lectus Road', 'MT79GXWA35244171115438677079222'),
('SJ551520', 'Baxter', 'Terry', 'ac.facilisis@google.edu', '1-271-630-2561', '199-2550 Dapibus Rd.', 'AT419856353115819512'),
('SV544669', 'Iliana', 'Williams', 'mollis.dui@aol.ca', '1-862-274-7271', '136-6928 Malesuada Rd.', 'RO73AEGR2889894757289728'),
('UC008723', 'Owen', 'Cabrera', 'quam.dignissim.pharetra@hotmail.com', '1-636-729-3680', '182-4733 Vestibulum St.', 'CZ9436685167200518696172'),
('UJ175101', 'Paula', 'Landry', 'a.purus@hotmail.ca', '(567) 827-8093', '5346 Magna. Ave', 'HU03221488629355502325880117'),
('VG763973', 'Arden', 'Reese', 'elit@protonmail.edu', '(368) 745-7637', '6566 Varius Ave', 'RO49WYKO8493371357511468'),
('ZD060311', 'Veda', 'Ruiz', 'urna@yahoo.edu', '1-344-621-9854', 'Ap #208-8594 Et Road', 'AZ16529611755593719751676895');

-- --------------------------------------------------------

--
-- Table structure for table `uzsakymas`
--

CREATE TABLE `uzsakymas` (
  `uzsakymo_nr` varchar(9) NOT NULL,
  `kiekis` int(11) NOT NULL,
  `fk_skaitytojo_kodas` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `uzsakymas`
--

INSERT INTO `uzsakymas` (`uzsakymo_nr`, `kiekis`, `fk_skaitytojo_kodas`) VALUES
('100000001', 1, 'BK539762'),
('100000002', 1, 'CF272375'),
('100000003', 1, 'FM274967'),
('100000004', 1, 'AF863228'),
('100000005', 1, 'LO407394'),
('100000006', 1, 'GA819458'),
('100000007', 1, 'ML760400'),
('100000008', 1, 'MP550316'),
('100000009', 1, 'JX334468'),
('100000010', 2, 'HB644163');

-- --------------------------------------------------------

--
-- Table structure for table `uzsakyta_kopija`
--

CREATE TABLE `uzsakyta_kopija` (
  `data_nuo` date NOT NULL,
  `data_iki` date NOT NULL,
  `id_UZSAKYTA_KOPIJA` int(11) NOT NULL,
  `fk_KOPIJAnr` int(11) NOT NULL,
  `fk_KOPIJAbruksninis_kodas` varchar(30) NOT NULL,
  `fk_skaitytojo_kodas` varchar(8) NOT NULL,
  `fk_uzsakymo_nr` varchar(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `uzsakyta_kopija`
--

INSERT INTO `uzsakyta_kopija` (`data_nuo`, `data_iki`, `id_UZSAKYTA_KOPIJA`, `fk_KOPIJAnr`, `fk_KOPIJAbruksninis_kodas`, `fk_skaitytojo_kodas`, `fk_uzsakymo_nr`) VALUES
('2022-03-01', '2022-03-31', 3, 38, '456-72-65861-78-8', 'BK539762', '100000001'),
('2022-03-01', '2022-03-31', 4, 51, '611-81-43072-23-4', 'CF272375', '100000002'),
('2022-03-01', '2022-03-31', 5, 24, '275-58-41703-53-1', 'FM274967', '100000003'),
('2022-01-20', '2022-02-20', 6, 30, '332-45-67847-56-6', 'AF863228', '100000004'),
('2022-02-15', '2022-03-17', 7, 46, '564-32-88055-73-3', 'LO407394', '100000005'),
('2022-02-01', '2022-03-03', 8, 21, '178-46-66207-23-5', 'GA819458', '100000006'),
('2022-03-03', '2022-04-02', 10, 20, '178-46-66207-23-5', 'MP550316', '100000008'),
('2022-03-03', '2022-04-02', 11, 58, '655-76-08173-70-1', 'JX334468', '100000009');

-- --------------------------------------------------------

--
-- Table structure for table `zanras`
--

CREATE TABLE `zanras` (
  `pavadinimas` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `zanras`
--

INSERT INTO `zanras` (`pavadinimas`) VALUES
('Action'),
('Adventure'),
('Animation'),
('Art'),
('Autobiography'),
('Biography'),
('Children\'s'),
('Comedy'),
('Contemporary'),
('Family'),
('Fantasy'),
('Food and Drink'),
('Graphic Novel'),
('Guide/How-to'),
('History'),
('Horror'),
('LGBTQ+'),
('Magical Realism'),
('Memoir'),
('Musical'),
('Mystery'),
('Novel'),
('Parenting and Family'),
('Photography'),
('Religion'),
('Romance'),
('Sci-Fi'),
('Science'),
('Self-help'),
('Spirituality'),
('Technology'),
('Thriller'),
('Travel'),
('True Crime');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `autorius`
--
ALTER TABLE `autorius`
  ADD PRIMARY KEY (`autoriaus_kodas`);

--
-- Indexes for table `darbuotojas`
--
ALTER TABLE `darbuotojas`
  ADD PRIMARY KEY (`darbuotojo_kodas`),
  ADD KEY `dirba` (`fk_FILIALASfil_kodas`);

--
-- Indexes for table `delsimas`
--
ALTER TABLE `delsimas`
  ADD PRIMARY KEY (`skolos_suma`,`fk_uzsakymo_nr`,`fk_skaitytojo_kodas`),
  ADD UNIQUE KEY `fk_uzsakymo_nr` (`fk_uzsakymo_nr`),
  ADD KEY `pritaikomas` (`fk_skaitytojo_kodas`);

--
-- Indexes for table `filialas`
--
ALTER TABLE `filialas`
  ADD PRIMARY KEY (`fil_kodas`);

--
-- Indexes for table `knyga`
--
ALTER TABLE `knyga`
  ADD PRIMARY KEY (`bruksninis_kodas`);

--
-- Indexes for table `kopija`
--
ALTER TABLE `kopija`
  ADD PRIMARY KEY (`nr`,`fk_KNYGAbruksninis_kodas`),
  ADD KEY `turi` (`fk_KNYGAbruksninis_kodas`);

--
-- Indexes for table `mokejimas`
--
ALTER TABLE `mokejimas`
  ADD PRIMARY KEY (`data`,`fk_SASKAITAsaskaitos_numeris`,`fk_SKAITYTOJASskaitytojo_kodas`),
  ADD KEY `padengia` (`fk_SASKAITAsaskaitos_numeris`),
  ADD KEY `sumoka` (`fk_SKAITYTOJASskaitytojo_kodas`);

--
-- Indexes for table `parase`
--
ALTER TABLE `parase`
  ADD PRIMARY KEY (`fk_AUTORIUSautoriaus_kodas`,`fk_KNYGAbruksninis_kodas`),
  ADD KEY `parase1` (`fk_KNYGAbruksninis_kodas`);

--
-- Indexes for table `priklauso`
--
ALTER TABLE `priklauso`
  ADD PRIMARY KEY (`fk_ZANRASpavadinimas`,`fk_KNYGAbruksninis_kodas`),
  ADD KEY `priklauso1` (`fk_KNYGAbruksninis_kodas`);

--
-- Indexes for table `registracija`
--
ALTER TABLE `registracija`
  ADD PRIMARY KEY (`fk_SKAITYTOJASskaitytojo_kodas`) USING BTREE,
  ADD KEY `fk_DARBUOTOJASdarbuotojo_kodas` (`fk_DARBUOTOJASdarbuotojo_kodas`) USING BTREE,
  ADD KEY `fk_FILIALASfil_kodas` (`fk_FILIALASfil_kodas`) USING BTREE;

--
-- Indexes for table `saskaita`
--
ALTER TABLE `saskaita`
  ADD PRIMARY KEY (`saskaitos_numeris`,`fk_SKAITYTOJAS_skaitytojo_kodas`,`fk_UZSAKYMAS_uzsakymo_nr`),
  ADD UNIQUE KEY `fk_DELSIMAS_skolos_suma` (`fk_DELSIMAS_skolos_suma`),
  ADD KEY `apmokamas` (`fk_UZSAKYMAS_uzsakymo_nr`),
  ADD KEY `apmakamas2` (`fk_SKAITYTOJAS_skaitytojo_kodas`);

--
-- Indexes for table `skaitytojas`
--
ALTER TABLE `skaitytojas`
  ADD PRIMARY KEY (`skaitytojo_kodas`);

--
-- Indexes for table `uzsakymas`
--
ALTER TABLE `uzsakymas`
  ADD PRIMARY KEY (`uzsakymo_nr`,`fk_skaitytojo_kodas`),
  ADD KEY `uzsako` (`fk_skaitytojo_kodas`);

--
-- Indexes for table `uzsakyta_kopija`
--
ALTER TABLE `uzsakyta_kopija`
  ADD PRIMARY KEY (`id_UZSAKYTA_KOPIJA`),
  ADD UNIQUE KEY `fk_KOPIJAnr` (`fk_KOPIJAnr`,`fk_KOPIJAbruksninis_kodas`),
  ADD KEY `itraukta_i` (`fk_KOPIJAbruksninis_kodas`),
  ADD KEY `sudaryta_is` (`fk_skaitytojo_kodas`),
  ADD KEY `sudaryta_is1` (`fk_uzsakymo_nr`);

--
-- Indexes for table `zanras`
--
ALTER TABLE `zanras`
  ADD UNIQUE KEY `pavadinimas` (`pavadinimas`) USING BTREE;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `darbuotojas`
--
ALTER TABLE `darbuotojas`
  ADD CONSTRAINT `dirba` FOREIGN KEY (`fk_FILIALASfil_kodas`) REFERENCES `filialas` (`fil_kodas`);

--
-- Constraints for table `delsimas`
--
ALTER TABLE `delsimas`
  ADD CONSTRAINT `pritaikomas` FOREIGN KEY (`fk_skaitytojo_kodas`) REFERENCES `uzsakymas` (`fk_skaitytojo_kodas`),
  ADD CONSTRAINT `pritaikomas1` FOREIGN KEY (`fk_uzsakymo_nr`) REFERENCES `uzsakymas` (`uzsakymo_nr`);

--
-- Constraints for table `kopija`
--
ALTER TABLE `kopija`
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_KNYGAbruksninis_kodas`) REFERENCES `knyga` (`bruksninis_kodas`);

--
-- Constraints for table `mokejimas`
--
ALTER TABLE `mokejimas`
  ADD CONSTRAINT `padengia` FOREIGN KEY (`fk_SASKAITAsaskaitos_numeris`) REFERENCES `saskaita` (`saskaitos_numeris`),
  ADD CONSTRAINT `sumoka` FOREIGN KEY (`fk_SKAITYTOJASskaitytojo_kodas`) REFERENCES `skaitytojas` (`skaitytojo_kodas`);

--
-- Constraints for table `parase`
--
ALTER TABLE `parase`
  ADD CONSTRAINT `parase` FOREIGN KEY (`fk_AUTORIUSautoriaus_kodas`) REFERENCES `autorius` (`autoriaus_kodas`),
  ADD CONSTRAINT `parase1` FOREIGN KEY (`fk_KNYGAbruksninis_kodas`) REFERENCES `knyga` (`bruksninis_kodas`);

--
-- Constraints for table `priklauso`
--
ALTER TABLE `priklauso`
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_ZANRASpavadinimas`) REFERENCES `zanras` (`pavadinimas`),
  ADD CONSTRAINT `priklauso1` FOREIGN KEY (`fk_KNYGAbruksninis_kodas`) REFERENCES `knyga` (`bruksninis_kodas`);

--
-- Constraints for table `registracija`
--
ALTER TABLE `registracija`
  ADD CONSTRAINT `registruojasi` FOREIGN KEY (`fk_SKAITYTOJASskaitytojo_kodas`) REFERENCES `skaitytojas` (`skaitytojo_kodas`),
  ADD CONSTRAINT `vykdo` FOREIGN KEY (`fk_DARBUOTOJASdarbuotojo_kodas`) REFERENCES `darbuotojas` (`darbuotojo_kodas`),
  ADD CONSTRAINT `vyksta` FOREIGN KEY (`fk_FILIALASfil_kodas`) REFERENCES `filialas` (`fil_kodas`);

--
-- Constraints for table `saskaita`
--
ALTER TABLE `saskaita`
  ADD CONSTRAINT `apmakamas2` FOREIGN KEY (`fk_SKAITYTOJAS_skaitytojo_kodas`) REFERENCES `delsimas` (`fk_skaitytojo_kodas`),
  ADD CONSTRAINT `apmokamas` FOREIGN KEY (`fk_UZSAKYMAS_uzsakymo_nr`) REFERENCES `delsimas` (`fk_uzsakymo_nr`),
  ADD CONSTRAINT `apmokamas1` FOREIGN KEY (`fk_DELSIMAS_skolos_suma`) REFERENCES `delsimas` (`skolos_suma`);

--
-- Constraints for table `uzsakymas`
--
ALTER TABLE `uzsakymas`
  ADD CONSTRAINT `uzsako` FOREIGN KEY (`fk_skaitytojo_kodas`) REFERENCES `skaitytojas` (`skaitytojo_kodas`);

--
-- Constraints for table `uzsakyta_kopija`
--
ALTER TABLE `uzsakyta_kopija`
  ADD CONSTRAINT `itraukta_i` FOREIGN KEY (`fk_KOPIJAbruksninis_kodas`) REFERENCES `kopija` (`fk_KNYGAbruksninis_kodas`),
  ADD CONSTRAINT `itraukta_i1` FOREIGN KEY (`fk_KOPIJAnr`) REFERENCES `kopija` (`nr`),
  ADD CONSTRAINT `sudaryta_is` FOREIGN KEY (`fk_skaitytojo_kodas`) REFERENCES `uzsakymas` (`fk_skaitytojo_kodas`),
  ADD CONSTRAINT `sudaryta_is1` FOREIGN KEY (`fk_uzsakymo_nr`) REFERENCES `uzsakymas` (`uzsakymo_nr`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
