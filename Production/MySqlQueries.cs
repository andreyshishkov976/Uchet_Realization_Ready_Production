﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production
{
    public class MySqlQueries
    {
        //Select

        public string Select_Sklad = $@"SELECT ID_Sklada AS 'ID Склада', Name AS 'Наименование склада' FROM sklad;";

        public string Select_Sklad_ComboBox = $@"SELECT Name AS 'Наименование склада' FROM sklad;";

        public string Select_Sklad_ID = $@"SELECT ID_Sklada AS 'ID Склада'FROM sklad WHERE Name = @Value1 ;";

        public string Select_Product = $@"SELECT product.ID_Product AS 'ID Продукции', product.Name AS 'Наименование продукции',product.Ed_Izm AS 'Единицы измерения', sklad.Name AS 'Хранится на складе'
FROM product INNER JOIN sklad ON product.ID_Sklada = sklad.ID_Sklada;";

        public string Select_Product_ComboBox_CUP = $@"SELECT product.Name AS 'Наименование продукции'
FROM product INNER JOIN sklad ON product.ID_Sklada = sklad.ID_Sklada
WHERE product.ID_Sklada = 1;";

        public string Select_Product_ComboBox_GP = $@"SELECT product.Name AS 'Наименование продукции'
FROM product INNER JOIN sklad ON product.ID_Sklada = sklad.ID_Sklada
WHERE product.ID_Sklada = 2;";

        public string Select_Product_ID = $@"SELECT product.ID_Product AS 'ID Продукции'
FROM product INNER JOIN sklad ON product.ID_Sklada = sklad.ID_Sklada
WHERE product.Name = @Value1;";

        public string Select_Organizacii = $@"SELECT ID_Organizacii AS 'ID Заказчика', Name AS 'Наименование организации заказчика', Adress AS 'Адрес доставки'
FROM organizacii;";

        public string Select_Zayavka = $@"SELECT zayavka.ID_Zayavki AS 'Заявка, №', sklad.Name AS 'Отгрузка со склада', zayavka.Date AS 'Дата отгрузки'
FROM zayavka INNER JOIN sklad ON zayavka.ID_Sklada = sklad.ID_Sklada;";

        public string Select_All_Zakaz = $@"SELECT zakaz.ID_Zakaza AS 'Заказ, №', organizacii.Name AS 'Наименование организации заказчика', zakaz.Date AS 'Дата заказа', COUNT(sostav_zakaza.ID_Zakaza) AS 'Количество позиций', zakaz.Identify AS 'Состояние'
FROM zakaz INNER JOIN organizacii ON zakaz.ID_Organizacii = organizacii.ID_Organizacii
LEFT JOIN sostav_zakaza ON zakaz.ID_Zakaza = sostav_zakaza.ID_Zakaza
GROUP BY zakaz.ID_Zakaza;";

        public string Select_Done_Zakaz = $@"SELECT zakaz.ID_Zakaza AS 'Заказ, №', organizacii.Name AS 'Наименование организации заказчика', zakaz.Date AS 'Дата заказа', COUNT(sostav_zakaza.ID_Zakaza) AS 'Количество позиций'
FROM zakaz INNER JOIN organizacii ON zakaz.ID_Organizacii = organizacii.ID_Organizacii
LEFT JOIN sostav_zakaza ON zakaz.ID_Zakaza = sostav_zakaza.ID_Zakaza
WHERE zakaz.Identify = 'Огружен'
GROUP BY zakaz.ID_Zakaza;";

        public string Select_Wait_Zakaz = $@"SELECT zakaz.ID_Zakaza AS 'Заказ, №', organizacii.Name AS 'Наименование организации заказчика', zakaz.Date AS 'Дата заказа', COUNT(sostav_zakaza.ID_Zakaza) AS 'Количество позиций'
FROM zakaz INNER JOIN organizacii ON zakaz.ID_Organizacii = organizacii.ID_Organizacii
LEFT JOIN sostav_zakaza ON zakaz.ID_Zakaza = sostav_zakaza.ID_Zakaza
WHERE zakaz.Identify = 'Ожидает отгрузки'
GROUP BY zakaz.ID_Zakaza;";

        public string Select_All_Zakaz_2 = $@"SELECT zakaz.ID_Zakaza AS 'Заказ, №', zakaz.Date AS 'Дата заказа', COUNT(sostav_zakaza.ID_Zakaza) AS 'Количество позиций', zakaz.Identify AS 'Состояние'
FROM zakaz INNER JOIN organizacii ON zakaz.ID_Organizacii = organizacii.ID_Organizacii
LEFT JOIN sostav_zakaza ON zakaz.ID_Zakaza = sostav_zakaza.ID_Zakaza
WHERE zakaz.ID_Organizacii = @ID
GROUP BY zakaz.ID_Zakaza;";

        public string Select_Done_Zakaz_2 = $@"SELECT zakaz.ID_Zakaza AS 'Заказ, №', zakaz.Date AS 'Дата заказа', COUNT(sostav_zakaza.ID_Zakaza) AS 'Количество позиций'
FROM zakaz INNER JOIN organizacii ON zakaz.ID_Organizacii = organizacii.ID_Organizacii
LEFT JOIN sostav_zakaza ON zakaz.ID_Zakaza = sostav_zakaza.ID_Zakaza
WHERE zakaz.Identify = 'Огружен' AND zakaz.ID_Organizacii = @ID
GROUP BY zakaz.ID_Zakaza;";

        public string Select_Wait_Zakaz_2 = $@"SELECT zakaz.ID_Zakaza AS 'Заказ, №', zakaz.Date AS 'Дата заказа', COUNT(sostav_zakaza.ID_Zakaza) AS 'Количество позиций'
FROM zakaz INNER JOIN organizacii ON zakaz.ID_Organizacii = organizacii.ID_Organizacii
LEFT JOIN sostav_zakaza ON zakaz.ID_Zakaza = sostav_zakaza.ID_Zakaza
WHERE zakaz.Identify = 'Ожидает отгрузки' AND zakaz.ID_Organizacii = @ID
GROUP BY zakaz.ID_Zakaza;";

        public string Select_Sostav_CUP = $@"SELECT sostav_Zakaza.ID_Punkta, product.Name AS 'Наименование продукта', sostav_zakaza.Kolichestvo AS 'Количество'
FROM sostav_zakaza INNER JOIN zakaz ON sostav_zakaza.ID_Zakaza = zakaz.ID_Zakaza
INNER JOIN product ON sostav_zakaza.ID_Product = product.ID_Product
WHERE product.ID_Sklada = '1' AND sostav_zakaza.ID_Zakaza = @ID;";

        public string Select_Sostav_GP = $@"SELECT sostav_Zakaza.ID_Punkta, product.Name AS 'Наименование продукта', sostav_zakaza.Kolichestvo AS 'Количество'
FROM sostav_zakaza INNER JOIN zakaz ON sostav_zakaza.ID_Zakaza = zakaz.ID_Zakaza
INNER JOIN product ON sostav_zakaza.ID_Product = product.ID_Product
WHERE product.ID_Sklada = '2' AND sostav_zakaza.ID_Zakaza = @ID;";

        public string Select_Avtorizaciya = $@"SELECT EXISTS(SELECT * FROM login WHERE login.Login = @Value1 AND login.Parol = @Value2);";

        public string Select_User_Form = $@"SELECT login.ID_Organizacii FROM login WHERE login.Login = @Value1 AND login.Parol = @Value2;";

        public string Select_Last_Insert = $@"SELECT LAST_INSERT_ID();";
        
        //Select



        //Insert

        public string Insert_Sklad = $@"INSERT INTO sklad (Name) VALUES (@Value1);";

        public string Insert_Product = $@"INSERT INTO product (ID_Sklada, Name, Ed_Izm) VALUES (@Value1, @Value2, @Value3);";

        public string Insert_Organizacii = $@"INSERT INTO organizacii (Name, Adress) VALUES (@Value1, @Value2);";

        public string Insert_Zakaz = $@"INSERT INTO zakaz (ID_Organizacii, Date) VALUES (@ID, @Value1);";

        public string Insert_Sostav_Zakaza = $@"INSERT INTO sostav_zakaza (ID_Zakaza, ID_Product, Kolichestvo) VALUES (@ID, @Value1, @Value2);";

        //Insert



        //Update

        public string Update_Sklad = $@"UPDATE sklad SET Name = @Value1 WHERE ID_Sklada = @ID;";

        public string Update_Product = $@"UPDATE product SET ID_Sklada= @Value1, Name= @Value2, Ed_Izm = @Value3 WHERE ID_Product = @ID;";

        public string Update_Organizacii = $@"UPDATE organizacii SET Name = @Value1, Adress = @Value2 WHERE ID_Organizacii = @ID;";

        public string Update_Zakaz = $@"UPDATE zakaz SET ID_Organizacii = @Value1, Date = @Value2 WHERE ID_Zakaza = @ID;";

        //Update



        //Delete

        public string Delete_Sklad = $@"DELETE FROM sklad WHERE ID_Sklada = @ID;";

        public string Delete_Product = $@"DELETE FROM product WHERE ID_Product = @ID;";

        public string Delete_Organizacii = $@"DELETE FROM organizacii WHERE ID_Organizacii = @ID;";

        public string Delete_Zakaz = $@"DELETE FROM zakaz WHERE ID_Zakaza = @ID;";

        public string Delete_Sostav_Zakaza = $@"DELETE FROM sostav_zakaza WHERE ID_Punkta = @ID;";

        //Delete
    }
}
