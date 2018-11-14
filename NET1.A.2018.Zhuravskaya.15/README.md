# Day 15
 
### Queue
1. Разработать обобщенный типизированный класс-коллекцию [Queue](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.15/Queue/Queue.cs), реализующий основные операции для работы с очередью, и предоставляющий возможность итерирования по ней.
   - Итератор реализовать «вручную» (без использования блок-итератора yield).
   
2. Протестировать методы (NUnit) разработанного класса c использованием 
   * типов BCL: 
     - [QueueIntTests](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.15/QueueTests/QueueIntTests.cs) 
   * и кастомных типов:
     - [Email](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.15/QueueTests/CustomTypes/Email.cs) - [Tests](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.15/QueueTests/QueueEmailTests.cs) (не рализующих интерфейс IEquetable и не переопределяющих виртуальный метод Equals типа System.Object.)
     - [Profile](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.15/QueueTests/CustomTypes/Profile.cs) - [Tests](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.15/QueueTests/QueueProfileTests.cs) (не рализующих интерфейс IEquetable, переопределяющих виртуальный метод Equals типа System.Object.)
     - [Book](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.15/QueueTests/CustomTypes/Book.cs) - [Tests](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.15/QueueTests/QueueBookTests.cs) (рализующих интерфейс IEquetable, не переопределяющих виртуальный метод Equals типа System.Object.)
     - [TelephoneNumber](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.15/QueueTests/CustomTypes/TelephoneNumber.cs) - [Tests](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.15/QueueTests/QueueTelephoneNumberTests.cs) (рализующих интерфейс IEquetable и переопределяющих виртуальный метод Equals типа System.Object.) 


XML-комментарии к методам взяты из документации System.Collections.Generic.Queue.
