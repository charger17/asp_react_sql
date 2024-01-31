import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import * as API from "./services/data";
import Header from "./Header";

const StudentCalifications = () => {
  let params = useParams();

  const [calificaciones, setCalificaciones] = useState([]);
  const [calificacion, setCalificacion] = useState([]);

  useEffect(() => {
    API.getCalificaciones(params.matricula).then(setCalificaciones);
  }, [calificaciones]);

  let total = 0;

  calificaciones?.map(calificacion => (
    total = total + calificacion.nota * (calificacion.porcentaje/100)
  ));

  function createCalificacion(){
    let matricula = params.matricula;
   let descrField = document.getElementById('descripcion').value;
   let notaField = document.getElementById('nota').value;
   let porcentField = document.getElementById('porcentaje').value;

    let valid = descrField.trim() !== "" && notaField.trim() !== "" && porcentField.trim() !== "";

    if(valid){
        API.createCalificacion(calificacion, matricula).then(result => {
            if (result == "true") {
                alert("Calificacion añadida");
                document.getElementById('descripcion').value = '';
                document.getElementById('nota').value = '';
                document.getElementById('porcentaje').value = '';
                calificaciones.push(calificacion);
                return;
            }
            alert("Error al ingresar calificacion")
        })
    }
  }

  function deleteCalificacion(id){
    API.deleteCalificacion(id).then(result => {
        if (result == "true") {
            alert("Calificacion eliminada");
            
        }
        else{
            alert("Error al eliminar calificación.")
        }
    })
  }

  return (
    <>
      <Header />
      <table>
        <thead>
          <tr>
            <th>Descripcion</th>
            <th>Nota</th>
            <th>Ponderacion</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {calificaciones?.map((calificacion, index) => (
            <tr key={index}>
              <td>{calificacion.descripcion}</td>
              <td>{calificacion.nota}</td>
              <td>{calificacion.porcentaje} %</td>
              <td onClick={() => deleteCalificacion(calificacion.id)}>Eliminar</td>
            </tr>
          ))}
          <tr>
            <td>
              <input
                type="text"
                id="descripcion"
                placeholder="Descripcion"
                onChange={(event) =>
                  setCalificacion({
                    ...calificacion,
                    descripcion: event.target.value,
                  })
                }
              />
            </td>
            <td>
              <input
                type="number"
                id="nota"
                placeholder="Nota"
                onChange={(event) =>
                  setCalificacion({ ...calificacion, nota: event.target.value })
                }
              />
            </td>
            <td>
              <input
                type="number"
                id="porcentaje"
                placeholder="Ponderacion"
                onChange={(event) =>
                  setCalificacion({
                    ...calificacion,
                    porcentaje: event.target.value,
                  })
                }
              />
            </td>
            <td>
              <button id="nueva" onClick={() => createCalificacion()}>Nueva</button>
            </td>
          </tr>
        </tbody>
      </table>
      <p>Nota final: {total}</p>
    </>
  );
};

export default StudentCalifications;
