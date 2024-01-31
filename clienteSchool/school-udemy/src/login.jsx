import { useState } from 'react'
import * as API from './services/data';
import imagen from './assets/login-icon.png';
import {useNavigate} from 'react-router-dom'

const Login = () => {
    const [teacher, setTeacher] = useState({usuario: '', passsword: ''});
    const navigate = useNavigate();

    async function handleSubmit(e){
      e.preventDefault();
      const response = await API.login(teacher.usuario, teacher.passsword);
  
      if (response.length != 0) {
        sessionStorage.setItem("usuario", response);
        navigate('/dashboard');
      }
      else{
        alert("error");
  
      }
    }
    return (
      <>
      <img src={imagen} alt="" />
        <h1>Iniciar sesión</h1>
        <form action="" id="formulario" onSubmit={handleSubmit}>
          Usuario<input type="text" id="usuario" onChange={event => setTeacher({...teacher, usuario:event.target.value})}/><br />
          Password<input type="password" id="pass" onChange={event => setTeacher({...teacher, passsword:event.target.value})}/><br />
          <input type="submit" value="Enviar" />
        </form>
      </>
    );
};

export default Login;
