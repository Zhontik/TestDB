Так как я ни разу не работал с такой базой данных, то код написан, насколько мне позволяли знания.
Из-за сложностей я немного не реализовал UI и вывод всех пользователей, а также приватность полей.
Но для вывода всех пользователей достаточно правильно сформировать LINQ запрос в отдельном методе, что не сложно.

Собственно команды:
Всё общение происходит через класс editor

1 - Для создания нового полиса:

  editor.AddNewPolicy(
    new DateTime(2007, 8, 13),// start
    new DateTime(2007, 9, 24),// close
    "Alex", //name
    "Ads", //surname
    new DateTime(1937, 3, 5),//birth
    "MyHe",//Object name
    "House")//Object type (must be "Car", "Life" or "House")
                
2 - Обновление полиса:
  исходя из полей, что можно обновить оставалось только имя и тип страхуемого обьекта
  
  editor.UpdatePolicy(
    "Mar1", // номер полиса
    "insuredName", // имя поля, что надо обновить (must be "insuredName" or "insuredType")
    "qwe"); // Новое значение
    
3 - Получить полис:
  выводит в консоль информацию о полисе по номеру и возвращает сам полис.
  
  editor.FindNumber("Mar1"); // номер полиса
  
4 - Получить полисы по запросу:
  возвращает список плисов подходящих под условия или null, если таких нет.
  также выводит все полисы в консоль.
  
  // param - это масссив который хранит запросы в виде массива из 2 элементов.
  [0] - Слово запроса
  [1] - параметр запроса
  запрос может быть 1, а можно комбинировать несколько.
  
  string[][] param = 
  {
      new string[] {"Name", "Alex"},
      new string[] {"Surname", "Alex"},
      new string[] {"After", "22.03.2021"},
      new string[] {"Before", "22.03.2021"},
      new string[] {"Status", "Alex"},
      new string[] {"ObjectName", "Alex"}
  };             
  editor.Get(param);
  
  
  
  
                /*int num = datab.Policies.Count();
                Policy qwe = new Policy(
                    new DateTime(2007, 8, 13),//start
                    new DateTime(2007, 9, 24),//close
                    num++,
                    "Xern",//name
                    "Qwerty",//surname
                    new DateTime(1937, 3, 5),//birth
                    "MyHe",//OName  
                    "House",//OType
                    "Closed",//Status
                    new DateTime(2007, 8, 13)//LastUpdate
                    );
                datab.Policies.Add(qwe);
                datab.SaveChanges();*/
