opis wykonania:
utworzono klasę Data która za pomocą frameworka Newtonsoft.json dokonuje deserializacji wartości pliku json do odpowiednich typów danych.
pętla foreach przechodzi przez wszystkie obiekty jsona i sprawdza wartość właściwości 'operator' na podstawie której dokonuje
obliczeń matematycznych. następnie wartości są sortowane i są one zapisywane do zmiennej która przekazuje swoją zawartość do pliku
output.txt