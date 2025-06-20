# Opis funkcjonalności

- Użytkownik może stworzyć dowolną ilość sesji (konwersacji)
- W ramach każdej konwersacji użytkownik może wymieniać wiadomości z czatem
- Każda odpowiedź czata może być oceniana (na plus, na minus oraz możliwa jest zmiana bądź odznaczenie odpowiedzi)
- Użytkownik ma możliwość zatrzymania wykonywania zapytania do bota

## Tworzenie sesji
1) użytkownik wysyła pierwszą wiadomość
2) wraz z odpowiedzią dostaje id sesji

## Pobieranie listy sesji
1) użytkownik po wejściu do aplikacji pobiera i wyświetla listę sesji
2) użytkownik może wejść w każdą sesję i kontynuować rozmowę z botem od miejsca w którym skończył
## Lista wiadomości w sesji konwersacji
1) użytkownik po wejściu w sesję pobiera listę wcześniejszych wiadomości
2) ~~po przescrollowaniu na górę automatycznie albo po kliknięciu "pobierz wcześniejsze" pobieramy poprzednie X wiadomości~~
3) po wysłaniu nowej wiadomości scroll wraca do ostatniej wiadomości (smooth)