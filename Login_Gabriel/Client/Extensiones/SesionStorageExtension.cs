using Blazored.SessionStorage;
using System.Text.Json;
using System.Text;
using Login_Gabriel.Shared;

namespace Login_Gabriel.Client.Extensiones
{
    public static class SesionStorageExtension
    {
        //metodo para guardar nuesto objeto entro de una sesion Storage 
        public static async Task SaveStorage<T>(
            this ISessionStorageService sessionStorageService,
            string key, T item
            ) where T : class
        {
            //creamos una variable Json para serializar nuestro objeto
            var itemJson = JsonSerializer.Serialize( item );
            await sessionStorageService.SetItemAsStringAsync( key, itemJson ); //aqui se almacena 
        }

        //metodo para obtener el objeo que guardamos 
        public static async Task<T?> ObtenerStorage<T>(
            this ISessionStorageService sessionStorageService,
            string key
            ) where T : class
        {
            //creamos una variable Json para serializar nuestro objeto

            var itemJson = await sessionStorageService.GetItemAsStringAsync(key);
            
            if ( itemJson != null )
            {
                var item = JsonSerializer.Deserialize<T>( itemJson );// si el item es diferente a nulo lo obtenemos y desserializamos 
                return item;
            }else
            {
                return null;
            }
           
        }


    }
}
