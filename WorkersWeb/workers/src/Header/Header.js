import React from 'react';
import { useNavigate } from 'react-router-dom';
import { useSelector } from 'react-redux';
import './Header.css'; // קובץ CSS עם עיצובים נוספים

const ROUTES = {
  HOME: '/HomePage',
  EMPLOYEE_LIST: '/EmployeeList',
  LOG_IN: '/LogIn',
  LOG_OUT: '/LogOut'
};

const Header = () => {
  const navigate = useNavigate();
  const { user } = useSelector(state => ({
    user: state.User.user
  }));

  return (
    <div id="header">
      <div className="centered-buttons">
        {user && (
          <>
            <button className="link-button" onClick={() => navigate(ROUTES.HOME)}>
              <i className="home icon"></i>Home
            </button>
            <button className="link-button" onClick={() => navigate(ROUTES.EMPLOYEE_LIST)}>
              <i className="group icon"></i>Employees List
            </button>
          </>
        )}
        {user ? (
          <button className="link-button" onClick={() => navigate(ROUTES.LOG_OUT)}>
            <i className="log out icon"></i>Log Out
          </button>
        ) : (
          <>
            <button className="link-button" onClick={() => navigate(ROUTES.LOG_IN)}>
              <i className="sign in icon"></i>Log in
            </button>
          </>
        )}
      </div>
    </div>
  );
};

export default Header;
