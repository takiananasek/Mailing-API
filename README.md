# Mailing-API
Aplikacja pozwalająca na rejestracje klienta i obsługę serwisu mailowego za pomocą jego użytkowników. Wykorzystuje technologie takie jak ASP .NET Core, Entity Framework, XUnit i Moq, MailKit, MimeKit, Swagger, MailHog. Obejmuje: bazę danych, serwis obsługujący klienta SMTP, autoryzację użytkowników i klientów, customowe atrybuty kontrolerów, testy jednostkowe i integracyjne wszystkich funkcjonalności.

Powyższy kod jest jedynie fragmentem aplikacji, którą rozwijam, służy celom rekrutacyjnym. Pełny projekt dostępny jest w innym, prywatnym repozytorium.

Opis zaimplementowanych funkcjonlności:

1. Baza danych - wykorzystałam EF Core (code-first approach)

![pFk5S](https://user-images.githubusercontent.com/76755039/161141380-ae4b9724-9fd7-43c4-9b39-aa7ecb9f491f.png)

2. API - rejestracja użytkownika, klienta i ich walidacja
3. Wysyłanie Emaila - zaimplementowałam serwis mailingowy działający z pomocą MailHoga (Mailhog działa u mnie lokalnie w Dockerze)
4. Customowe filtry walidujące dane
5. Używam DTO do transportu danych
6. Obecnie pracuję nad: aktywacją użytkownika poprzez przesyłanie do niego linka aktywacyjnego
7. Testy do wszystkich funkcjonalności (jednostkowe i integracyjne - zmockowany DBContext dzięki klasom ukrytym w repozytoriach)

![api](https://user-images.githubusercontent.com/76755039/161141865-0caa62c6-4201-46e9-a6b9-30654f9538d9.PNG)
