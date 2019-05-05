<b>TO DO(14.04.2019(deadline))</b>

Читаем паттерны проектирования - Декоратор, Фабрика, Абстрактная фабрика, Одиночка, Стратегия, Адаптер, Шаблонный метод (TemplateMethod).
Рекомендуемые источники: 
    - 	Тепляков С. Паттерны проектирования на платформе .NET.
    - 	Элизабет Фримен, Эрик Фримен, Кэти Сиерра, Берт Бейтс. Паттерны проектирования.

1. Для объектов класса Book (ISBN, автор, название, издательство, год издания, количество страниц, цена) (домашнее задание 8-ого дня)
  реализовать возможность строкового представления различного вида **[Click here](https://github.com/RyokoAzuno/EPAM.BSUIR.Training/tree/master/NET.S.2019.Kazimirau.05/BooksApp)**.
  Например, для объекта со значениями ISBN = 978-0-7356-6745-7, AuthorName  =JeffreyRichter, Title = CLR via C#, Publisher = MicrosoftPress, Year = 2012, NumberOPpages = 826, Price = 59.99$, могут быть следующие варианты:
  -	Jeffrey Richter, CLR via C#
  -	Jeffrey Richter, CLR via C#, "Microsoft Press", 2012
  -	ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, "Microsoft Press", 2012, P. 826.
  -	Jeffrey Richter, CLR via C#, "Microsoft Press", 2012
  -	ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, "Microsoft Press", 2012, P. 826., 59.99$.
и т.д.
2. Не изменяя класс Book, добавить для объектов данного класса дополнительную возможность форматирования, изначально не предусмотренную классом.**[Click here](https://github.com/RyokoAzuno/EPAM.BSUIR.Training/tree/master/NET.S.2019.Kazimirau.05/BooksApp)** 
3. Для реализованных в пп. 1, 2 функциональностей разработать модульные тесты.**[Click here](https://github.com/RyokoAzuno/EPAM.BSUIR.Training/tree/master/NET.S.2019.Kazimirau.05/BooksApp/Tests)**
4. Выполнить рефакторинг класса (с целью сокращения повторного кода) в алгоритмах Евклида (для рефакторинга использовать делегаты, рефакторинг возможен только в случае, когда все метод находятся в одном классе!). Интерфейс класса измениться не должен.**[Click here](https://github.com/RyokoAzuno/EPAM.BSUIR.Training/tree/master/NET.S.2019.Kazimirau.03/GCD)**
5. В класс с алгоритмом сортировки не прямоугольной матрицы, принимающим как компаратор интерфейс IComparer<int[]> добавить метод, принимающий как параметр делегат-компаратор, инкапсулирующий логику сравнения строк матрицы. Протестировать работу разработанного метода на примере сортировки матрицы, используя прежние критерии сравнения. Класс реализовать двумя способами, «замкнув» в первом варианте реализацию метода сортировки с делегатом на метод с интерфейсом, во втором – наоборот.**[Click here](https://github.com/RyokoAzuno/EPAM.BSUIR.Training/tree/master/NET.S.2019.Kazimirau.04/JaggedArraySorter)**

