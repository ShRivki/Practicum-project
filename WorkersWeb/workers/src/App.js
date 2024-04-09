import './App.css';
import { Route, Routes } from "react-router-dom";
import Header from './Header/Header.js'
import Error from './Error.js';
import React from 'react';

const HomePage = React.lazy(() => import('./HomePage.js'));
const LogIn = React.lazy(() => import('./User/LogIn.js'));
const LogOut = React.lazy(() => import('./User/LogOut.js'));
const EmployeeList = React.lazy(() => import('./Employee/EmployeeList.js'));
const AddEmployee = React.lazy(() => import('./Employee/AddEmployee.js'));
const EmployeeDetails = React.lazy(() => import('./Employee/EmployeeDetails.js'));

function App() {
  return (
    <>
      <Header />
      <div id="body" >
        <div id="body1">
          <div id="body2">
            <Routes>
              <Route path="/" element={<React.Suspense fallback={<div>Loading...</div>}><HomePage /></React.Suspense>} />
              <Route path="/HomePage" element={<React.Suspense fallback={<div>Loading...</div>}><HomePage /></React.Suspense>} />
              <Route path="/Login" element={<React.Suspense fallback={<div>Loading...</div>}><LogIn /></React.Suspense>} />
              <Route path="/LogOut" element={<React.Suspense fallback={<div>Loading...</div>}><LogOut /></React.Suspense>} />
              <Route path="/EmployeeList" element={<React.Suspense fallback={<div>Loading...</div>}><EmployeeList /></React.Suspense>}>
                <Route path="EmployeeDetails" element={<React.Suspense fallback={<div>Loading...</div>}><EmployeeDetails /></React.Suspense>} />
                <Route path="AddEmployee" element={<React.Suspense fallback={<div>Loading...</div>}><AddEmployee /></React.Suspense>} />
              </Route>
              <Route path="/*" element={<Error />} />
            </Routes>
          </div>
        </div>
      </div>
    </>
  );
}

export default App;
