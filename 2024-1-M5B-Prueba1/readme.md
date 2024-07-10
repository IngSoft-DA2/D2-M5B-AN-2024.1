# Prueba de tecnología M5B-AN

### La solución compila pero al realizar una request tira una exepción.
* Resuelva este problema de la forma más adecuada vista en clase.

### Pruebas unitarias
* Realice las pruebas unitarias **(utilizando mocks)** necesarias para probar en su completitud el método `GetMainDrug` ubicado en `Medicines/MedicineService.cs`.

### Respuesta común para todos los controladores
* Ahora todas las respuestas de la WebAPI deben cumplir con el siguiente formato:
```json
    {
        "success": true,
        "response": "paracetamol"
    }
```
* `success`: su valor puede ser true en caso que la operación se realice con éxito, o false si se arroja alguna excepción.
* `response`: es la respuesta del método del controlador, en caso de que la operación falló, debe mostrar el mensaje de la excepción.
    * Por ejemplo en `MedicineController.cs` el método `Get` el valor debe ser la lista de `Medicine` y en el caso de `MainDrug` debe ser un `string`.
* Utilice la forma que usted considere más adecuada con lo visto en clase para resolver este problema.