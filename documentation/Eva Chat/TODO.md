## Backend

✅ Postawienie aplikacji
✅ Stworzenie modeli DB
✅ Konfiguracja MediaR
✅  Stworzenie logiki odpowiedzialnej za przyjmowanie requestów
	- ✅ stworzenie modeli DTO
	- ✅  pobieranie listy sesji
	- ✅  pobieranie historii wiadomości w sesji
	- ✅  ocena wiadomości
	- ✅ pytanie do czata (tworzenie nowej wiadomości i streamowanie odpowiedzi)
✅  Zapis wiadomości do DB
	- ✅ konfiguracja bazy danych
	- ✅ Składanie całości odpowiedzi do zapisu (albo do końca albo do przerwania)
⬜️ Przetestować z prawdziwym modelem (opcjonalnie)
⬜️ Rozbudować serwis fejkowego czatu by był bardziej zróżnicowany
✅ Konfiguracja CORS do dev
⬜️ Testy


## Frontend
✅  Stworzenie layoutu
✅  Komponent z listą sesji
✅  Komponent czatu
⬜️ Testy
⬜️ Przenieść konfigurację
⬜️ Obsługa błędów


## Zostawione na jutro... 
✅  Przetestować połączenie do bazy
⬜️ Posprzątać DTO i inny nieużywany kod
✅  Sprawdzić co sie dzieje z anulowaniem - czy ten Cancelation Token poprawnie zadziała tak jak myślę.. 

## Znalezione bugi
⬜️ Po stworzeniu nowej sesji a następnie od razu kliknięciu w przycisk "nowa sesja" zostają stare wiadomości - to przez to że podmieniam link na "miękko", co sprawia że router nie wie że sie zmieniła strona. Dodałem tam opcję z reloadem po przeładowaniu na tą samą stronę ale nie zadziałało.
