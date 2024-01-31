const URL = "https://localhost:7088/api/";


export function login(usuario, pass) {
    let datos = {usuario: usuario, pass: pass};

    return fetch(URL + "autenticacion", {
        method: 'POST',
        body: JSON.stringify(datos),
        headers:{
            'Content-Type': 'application/json'
        }
    })
    .then(data => data.text());
}

export function getStudents(usuario){
    return fetch(URL + "alumnosProfesor?usuario=" + usuario,{
        headers:{
            'Content-Type': 'application/json'
        }
    }).then(data => data.json()).catch(error => {
        console.error(error);
    });
}

export function createStudent(student){
    let data = {dni:student.dni, nombre:student.nombre, direccion:student.direccion, edad:student.edad, email:student.email, asignatura:student.asignatura}
    return fetch(URL + "alumno?id_asig=" + student.asignatura, {
        method: 'POST',
        body: JSON.stringify(data),
        headers:{
            'Content-Type': 'application/json'
        }
    })
    .then(data => data.text()).catch(error => {
        console.error(error);
    });
}

export function deleteStudent(id){
    console.log(URL + "alumno?id=" + id)
    return fetch (URL + "alumno?id=" + id,{
        method: 'DELETE',
        headers:{
            'Content-Type': 'application/json'
        }
    })
    .then(data => data.text()).catch(error => {
        console.error(error);
    });
}