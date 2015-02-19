# Prototype3D
Тестовое задание для программиста Unity3D

1. Все, что не оговорено – на ваше усмотрение.
2. Создать проект, в котором будет одна сцена.
3. Содержание сцены:
+a. Некая поверхность, не имеет значения ее форма и размер.
+b. Чуть-чуть освещения, чтобы можно было без проблем видеть, что происходит на этой поверхности.
+c. Свободно плавающая по сцене камера.
d. 15-20 объектов, представляющих собой неких юнитов.
4. Что требуется реализовать:
+a. Реализовать свободное перемещение камеры по сцене – передвижение – стандартный wsad, ориентация камеры движениями мыши.
b. При нажатии на левую кнопку мыши, если центр камеры смотрит на вышеуказанную поверхность, на ней должен появиться новый юнит в указанном месте с рандомными, по возможности, уникальными параметрами.
c. При нажатии на правую кнопку мыши, если центр камеры смотрит на определенного персонажа, он должен быть уничтожен.
d. Реализовать хранение данных о юнитах (далее «информация»): название юнита, уровень, тип (абсолютно абстрактные значения).
e. Реализовать отображение данных о юнитах.
i. При наведении на персонажа центра камеры, над ним должна отображаться информация о персонаже.
ii. Список находящихся на сцене персонажей должен отображаться в столбик в левой части экрана.
iii. Естественно, при изменении списка юнитов, находящихся в сцене, должны изменяться и с писки отображаемой информации.
5. На что будет обращаться внимание при оценке:
a. Четкость архитектуры проекта и написанного кода, его грамотное разбиение на компоненты и классы.
b. Масштабируемость системы: возможность добавления в информацию дополнительных параметров, общие затраты на модернизацию отдельных компонентов системы.
c. Ресурсоемкость функционирования системы.
6. На что не будет обращаться внимание:
a. Графика и дизайн проекта
b. Раскладка и конфигурация элементов интерфейса
7. Передать проект в виде не собранного решения (для анализа кода)
