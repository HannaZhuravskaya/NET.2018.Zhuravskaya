# Day 16
 
### BinarySearchTree

1. Разработать обобщенный класс-коллекцию [BinarySearchTree](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.16/BinarySearchTree/BinarySearchTree.cs) (бинарное дерево поиска). 
   * Предусмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. 
   * Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): для реализации использовать блок-итератор (yield). 
2. [Протестировать](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.16/BinarySearchTree.Tests/BinarySearchTreeTests.cs) разработанный класс, используя следующие типы:
   - System.Int32 (использовать сравнение по умолчанию и подключаемый компаратор);
   - System.String (использовать сравнение по умолчанию и подключаемый компаратор);
   - пользовательский класс [Book](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.16/BinarySearchTree.Tests/Book.cs), для объектов которого реализовано отношения порядка (использовать сравнение по умолчанию и подключаемый компаратор);
   - пользовательскую структуру [Point](https://github.com/HannaZhuravskaya/NET.2018.Zhuravskaya/blob/master/NET1.A.2018.Zhuravskaya.16/BinarySearchTree.Tests/Point.cs), для объектов которого не реализовано отношения порядка (использовать подключаемый компаратор).
