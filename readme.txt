========================= Sekcja INSTALATOR =========================

Aby instalator aplikacji zadziałał poprawnie w celeach demonstracyjnych, należy w pierwszej kolejności zainstalować certyfikat. W tym celu trzeba przejść do folderu "AppInstaller_1.0.0.0_Test" i wybrać AppInstaller_1.0.0.0_x86_x64.cer. Następnie opcja "Zainstaluj certyfikat...", dalej, w kolejnym kroku wybrać "Lokalna maszyna", następnie zaznaczyć opcję "Umieść wszystkie certyfikaty w następującym magazynie", kliknąć "Przeglądaj..." i wybrać "Zaufane główne urzędy certyfikacji", następnie dalej i zakończyć instalację.

========================= Sekcja DOKUMENTACJA =========================

Aplikacja mająca na celu wspomóc działania pracowników banku przy obsłudze klientów na co dzień.
Stosuje ona framewrok do zarządzania bazą danych "EntityFramework" wersja 6.4.4 w celu łatwej i przyjemnej obsłudze tabel w bazie danych.
NOTE: Przed rozpoczęciem zalecany jest import bazy danych w celu poprawnego działania aplikacji.

Przy pierwszym uruchomieniu aplikacja przywita użytkownika ekranem logowania do systemu. W tym celu należy użyć indentyfikatora składającego się z 14 znaków przypisanego do konkretnego pracownika banku (tabela Employee)
NOTE: Przykładowy identyfikator: LQt02*Hff$iQsX

Po zalogowaniu do systemu użytkownik ma przed sobą główny panel aplikacji, dwie sekcje: strefa klienta oraz strefa pracownika. Strefa klienta jest przeznaczona do operacji podczas obsługi klienta, sekcja pracwonika prezentuje dane o aktualnie zalogowanym pracowniku (użytkowniku).

Chcąc obsłużyć klienta, trzeba podać jego numer PESEL.
NOTE: Przykładowy numer PESEL: 99060393082

Po zaakceptowaniu klienta, pracownik ma dostęp do poszczególnych akcji (listy rozwijane), w zależności z czym przychodzi klient. Jeżeli pracownik będzie musiał obsłużyć następnego klienta, wystarczy że zamknie okno operacji poprzedniego klienta i poda nowy numer PESEL.

------------------ Podsekcja KOD ------------------

Aplikacja skłąda się z kilku okien do interakcji z użytkownikiem (typy plików .xaml) oraz kilku paneli (typy plików *Panel.cs). Okna pojawiają się po kliknięciu przysisków, zaś panele wypełniają przestrzeń środkową aplikacji w celu informowania użytkownika, w jakim miejscu się znajduje. W kodzie można znaleźć również pliki (typ pliku App'NazwaKontrolki'.cs), które zostały zastosowane w celu przejrzystości kodu i ułatwieniu pisania wyglądu aplikacji.