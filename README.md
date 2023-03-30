En este reto se ha llegado utilizar diferentes patrones y librerias que mueven la comunidad de dotnet.

A continuación se mencionara alguna de ellas:

- Se esta usando .NET 6 con C# 10 en Visual studio 2022, la api esta corriendo en contenedores linux mcr.microsoft.com/dotnet/aspnet:6.0.

- La estructura de proyecto esta basado en CleanArchitecture, un arquetipo que organiza entidades de dominio, persistencia y logica de negocio.

Para la persistencia se esta usando EntityFramework Core 6 con el storage InMemoryDatabase.

![imagen](https://user-images.githubusercontent.com/13544685/228938056-706a3b3a-1e36-4096-b298-e1a03677a062.png)

Requerimientos

- Solucion Tipo de Cambio

![imagen](https://user-images.githubusercontent.com/13544685/228938640-d68fe32d-9c61-4b8c-b5ea-7a4aafddef94.png)

- Metodo Calcular Tipo de Cambio

![imagen](https://user-images.githubusercontent.com/13544685/228939026-4232fb71-33c1-4dcf-9aa4-82c4e818ee76.png)

- Se debe crear la información del tipo de cambio en una in memorydatabaseu otra

![imagen](https://user-images.githubusercontent.com/13544685/228938056-706a3b3a-1e36-4096-b298-e1a03677a062.png)

- Dokerizar

![imagen](https://user-images.githubusercontent.com/13544685/228939410-b2cf7679-1185-4b23-ad1b-a16bb49a8eeb.png)

![imagen](https://user-images.githubusercontent.com/13544685/228939531-47760235-fbbd-47cd-b9c6-def5ec1baabf.png)


- El uso de la API debe ser mostrada desde Postman.

1. Obtener Token

![imagen](https://user-images.githubusercontent.com/13544685/228939847-4f9062a0-f8d0-4b20-a85f-429259240b11.png)

2. Cargar Data Inicial

![imagen](https://user-images.githubusercontent.com/13544685/228940040-899c2431-c4a8-422c-a7c7-e99ec1b79f99.png)

3. Consultar Monedas Registradas.

![imagen](https://user-images.githubusercontent.com/13544685/228940216-1f31fda5-0b0c-4b91-b5df-9f932d4d6d37.png)

4. Consultar Tipos de Cambios

![imagen](https://user-images.githubusercontent.com/13544685/228940358-935234b4-5409-4a26-8692-95e08ca6aaac.png)

5. Calcular Tipo de Cambio

![imagen](https://user-images.githubusercontent.com/13544685/228940733-f0b6fc30-0dee-447f-a16f-a4979f40a8c9.png)

6. Implementar un nivel de seguridad en la consulta (Token).

Para la autenticación se ha creado un endpoint basico '/login/signin' que nos devolverá un token en base a un usuario y contraseña.

![imagen](https://user-images.githubusercontent.com/13544685/228938237-40d90ce7-2b38-46a3-ac63-d636581d1f77.png)

Para la autorización, se han asignado los atributos [Authorize] a los controllers para no permitir su acceso si es que no tiene un token válido.

![imagen](https://user-images.githubusercontent.com/13544685/228938367-6649eb91-5208-45c0-a64e-751d75ace4a7.png)

Obtener Token
![imagen](https://user-images.githubusercontent.com/13544685/228939847-4f9062a0-f8d0-4b20-a85f-429259240b11.png)

7. Crear un POST para actualizar el valor del tipo de cambio.

![imagen](https://user-images.githubusercontent.com/13544685/228941515-1bbc61d5-949a-4134-8a78-c85ff88bc0ba.png)

![imagen](https://user-images.githubusercontent.com/13544685/228941652-d4d2d597-5f91-42ec-b3da-090592512ad0.png)

8. Angular
En proceso....







