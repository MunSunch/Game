# Game
## Задание 1. Программа «Карточная игра!»
Создать модель карточной игры.
Требования:
1. Класс Game формирует и обеспечивает:
  * Список игроков (минимум 2);
  * Колоду карт (36 карт);
  * Перетасовку карт (случайным образом);
  * Раздачу карт игрокам (равными частями каждому игроку);
  * Игровой процесс. Принцип: Игроки кладут по одной карте. У кого
       карта больше, то тот игрок забирает все карты и кладет их в конец своей
       колоды. Упрощение: при совпадении карт забирает первый игрок,
       шестерка не забирает туза. Выигрывает игрок, который забрал все карты.
2. Класс Player (набор имеющихся карт, вывод имеющихся карт).
3. Класс Karta (масть и тип карты (6-10, валет, дама, король, туз).
