# RegWhatsAppOpenCv

 Зареєструвати новий whatsApp аккаунт зараз можливо тільки через емулятор. Я обрав Nox через легкість встановлення.
Пошук координат для кліків виконуються за допомогою пошука фрагмента картинок на скріншоті через бібліотеку openCV.
Симуляція клавіатури та мишки виконано через бібліотеку InputManager.

Для запуску авто-регістратора потрібно:

1. Встановити емулятор NOX за посиланням https://ru.bignox.com
2. Запустити емулятор.
3. Встановити на емулятор WhatsApp Messenger !не через магазин!, а перетягнувши у вікно емулятору файл за посиланням https://drive.google.com/file/d/1LV68Z4sb8M0KnIEZav25ybWBMUw37kPY/view?usp=sharing
4. Запустити программу, переконавшись що вікно емулятору NOX видно повністью на моніторі


 Можливость для розвитку програми:
  Можна підключитися до емулятору за допомогою Android Debug Bridge, та замінит скріншоти на знаття xml розмітки екрану через команду adb uiautomator dump /dev/tty.
Далі за допомогою парсінга знайти елемент на який ми можемо натиснути. Зазвичай в ньому є тег content-desc у якому наприклад напис на кнопці, та bounds - координати x та y.
Складність у тому що для цього буде потрібно налаштувати емулятор зі студії, що займе більше часу.
