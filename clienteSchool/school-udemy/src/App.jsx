import {Routes, Route} from 'react-router-dom'
import Login from './login';
import Dashboard from './Dashboard';
import StudentNew from './StudentNew';


function App() {
  return(

      <Routes>
        <Route path='/' element={<Login />} />
        <Route path='/dashboard' element={<Dashboard/>}/>
        <Route path='/student' element={<StudentNew/>}/>
      </Routes>

  );
}

export default App
