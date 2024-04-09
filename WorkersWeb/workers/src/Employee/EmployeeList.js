import React, { useState, useEffect, useRef } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Outlet, useNavigate } from "react-router-dom";
import { useLocation } from "react-router-dom";
import { getEmployee, FindEmployee, deleteEmployee } from '../services/employeeService';
import { saveAs } from 'file-saver';
import '../App.css';

export function formatDateString(dateString) {
    const formattedDate = new Date(dateString).toLocaleDateString();
    return formattedDate;
}

const EmployeeList = ({ user, employees }) => {
    const [filter, setFilter] = useState("");
    const lastSearchTerm = useRef(null);
    const navigate = useNavigate();
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(getEmployee(user))
    }, []);

    useEffect(() => {
        const timer = setTimeout(() => {
            if (filter === lastSearchTerm.current) {
                setTimeout(() => {
                    if (filter !== "")
                        dispatch(FindEmployee(user, filter))
                    else
                        dispatch(getEmployee(user))
                }, 500);
            }
        }, 500);
        return () => clearTimeout(timer);
    }, [filter]);

    const handleChange = (e) => {
        setFilter(e.target.value);
        lastSearchTerm.current = e.target.value;
    };

    const handleExport = () => {
        const csvContent = employees.map(e => [e.firstName, e.lastName, e.identity, e.startDate].join(",")).join("\n");
        const csvBlob = new Blob([csvContent], { type: 'text/csv;charset=utf-8' });
        saveAs(csvBlob, 'employees.csv');
    };

    const printEmployee = (employee) => {
        return (
            <tr key={employee.id}>
                <td>{employee.firstName}</td>
                <td>{employee.lastName}</td>
                <td>{employee.identity}</td>
                <td>{formatDateString(employee.startDate)}</td>
                <td>
                    <button className="button but" disabled={localStorage.getItem('isDirector') == "false" && user.id == employee.id} onClick={() => {
                        navigate("AddEmployee", { state: employee });
                    }}>
                        <i className="edit outline icon"></i>
                    </button>
                </td>
                <td>
                    <button className="button but" disabled={user.id == employee.id} onClick={() => {
                        dispatch(deleteEmployee(employee.id));
                    }}>
                        <i className="trash alternate icon"></i>
                    </button>
                </td>
                <td>
                    <button className="button but" onClick={() => {
                        navigate("EmployeeDetails", { state: employee });
                    }}>
                        <i className="sidebar icon "></i>
                    </button>
                </td>
            </tr>
        );
    };

    return (
        <>
            <div className="ui rigth icon input">
                <input type="text" placeholder="Search..." value={filter} onChange={handleChange} />
                <i className="search icon"></i>
            </div>
            <button className="button" onClick={handleExport}><i className="file excel icon"></i> Export CSV</button>
            <button className="button" onClick={() => window.print()}><i className="print icon"></i> Print</button>
            <button className="button" onClick={() => navigate('AddEmployee')}><i className="add user icon"></i> Add Employee </button>
            <div id="taitel" className="ui horizontal divider header " style={{ fontSize: '24px', color: "rgb(19 23 122)" }}>Employees </div>
            <br />
            <div className="ui special cards printable-content">
                <table className="ui blue table ">
                    <thead>
                        <tr>
                            <th>firstName</th>
                            <th>lastName</th>
                            <th>identity</th>
                            <th>startDate</th>
                            <th>edit</th>
                            <th>-</th>
                            <th>details</th>
                        </tr>
                    </thead>
                    <tbody>
                        <Outlet />
                        {employees?.map((employee) =>
                            printEmployee(employee))}
                    </tbody>
                </table>
            </div>
        </>
    );
};

export default () => {
    const { state } = useLocation();
    const { user, employees } = useSelector(state => ({
        user: state.User.user,
        employees: state.Employee.employees
    }));

    return <EmployeeList user={user} employees={employees} />;
};
