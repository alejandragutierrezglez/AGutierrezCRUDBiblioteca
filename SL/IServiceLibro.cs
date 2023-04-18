using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceLibro" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceLibro
    {
        [OperationContract]
        ML.Result Add(ML.Libro libro);

        [OperationContract]
        ML.Result Update(ML.Libro libro);

        [OperationContract]
        ML.Result Delete(int IdLibro);


        [OperationContract]
        [ServiceKnownType(typeof(ML.Libro))]
        ML.Result GetAll();


        [OperationContract]
        [ServiceKnownType(typeof(ML.Libro))]
        ML.Result GetById(int IdLibro);

    }
}
