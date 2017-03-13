<h1>ОБЩАЯ ИНФОРМАЦМЯ</h1>

Данная  программа  производит  сравнение  содержимого двух  папок. В  параметрах
командной  строки  Вы  указываете  путь  к  первой  и  второй папке и запускаете 
программу.  После  этого  вычисляется  хэш функция  каждого файла.  В завершении  
Вы получаете список уникальных, не повторяющихся файлов.

<h1>ОТКАЗ ОТ ОТВЕТСТВЕННОСТИ</h1>
Данная   программа   не  поддерживаются   никакими    стандартными   программами
поддержки   и   обслуживания   со   стороны  автора.  Программа  предоставляются
«как  есть»  без  каких-либо гарантий.  Автор  отказывается  от  всех  гарантий,
включая, но не ограничиваясь  подразумеваемой гарантией товарной пригодности для
использования по  назначению или применимости  для какой-либо определенной цели.
Все риски, связанные  с использованием  или  последствиями использования  данной
программы, возлагаются на пользователя. 
Автор,  или иные  лица, участвовавшие  в  создании,  производстве  или  доставке
программы,  ни  при каких  обстоятельствах  не несут  ответственности  за  любые
убытки (включая помимо прочего убытки  в связи с упущенной  выгодой, прерыванием
бизнес-деятельности, потерей деловой информации или другие материальные убытки),
возникающие  из-за использования   или  невозможности   использования  программы
или   документации,   даже   если   Автор  был    предупрежден   о   возможности
таких убытков.

<h1>ИЗВЕСТНЫЕ ОШИБКИ И ОСОБЕННОСТИ:</h1>

<b>[fixed]
[bug]</b> 16.11.2015 - Если в списке параметров указать первым параметром /? а потом
указать  еще параметры или  любой текст, то это приведет к аварийному завершению
программы и выводу ошибки "Illegal characters in path.".

<b>[fixed]
[bug]</b> 16.11.2015  -  Если программа пытается получить доступ к занятому файлу то
это приводит  к  аварийному  завершению  программы и выводу сообщения об ошибки.
В тексте сообщения среди прочего   содержится следующая  информация "The process
cannot access the file".

<b>[fixed]
[warning]</b> 16.11.2015  -  При  запуске   программы   не  происходит  проверка  на
существование  папок. Это  приводит  к тому, что  о существовании  второй  папки
программа  узнает только в  тот момент  когда обращается к ней - после обработки
первой папки.  Если  второй папки  не  существует  то  программа  выдает  ошибку
"Could not find a part of the path"

<b>[information]</b> 16.11.2015  -  Если  имена  файлов   отличаются,   но   содержимое
одинаковое,  то  это  воспринимается  программой  как одинаковые файлы. Проверка
производится только  по содержимому и  не учитывает путь, имя  и другие атрибуты
файла. Данное поведение возможно будет изменено в следующих версиях.

<b>[information]</b> 16.11.2015  - В  операционной  системе  Windows 10  при  работе  в
среде с английским интерфейсом  русские символы  в консоле могут отображаться не 
корректно. 

<b>[fixed]</b> v.1.0.1.19 от 13.03.2017
<b>[bug]</b> 16.11.2015  -  Если  программе  в  качестве  первого или второго аргумента 
встречается  путь  заключенный  в  кавычки  и  содержащий пробелы, при этом путь 
оканчивается слешом, то такой путь не воспринимается. 
Например "c:\Mikhail Danshin\". 
Так  же  программа  не  воспринимает  если  встречает путь заключенный в кавычки 
оканчивающийся на слэш. Например "c:\Mikhail\".

<h2>АВТОР:</h2>
Даньшин Михаил<br>
Блог – http://danshin.ms<br>
Facebook - https://www.facebook.com/Danshin.ms<br>
E-Mail: - mdanshin@gmail.com<br>
