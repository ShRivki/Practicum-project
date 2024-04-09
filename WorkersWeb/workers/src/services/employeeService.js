import * as actionType from '../store/actions';
import axios from "axios";
import Swal from "sweetalert2";

const URL = 'https://localhost:7079/api/Employee';

const filterEmployeesByManagementRole = (user, employees) => {
    if (localStorage.getItem('isDirector') === "true")
        return employees;
    const userManagementRoles = user.roles.filter(role => role.isManagement);
    if (userManagementRoles.length === 0) {
        return [];
    }
    const filteredEmployees = employees.filter(employee => {
        return userManagementRoles.some(userRole => {
            return employee.roles.some(role => {
                return role.role.id === userRole.role.id || user.id === employee.id;
            });
        });
    });
    return filteredEmployees;
}

export const getEmployee = (user) => {
    return async dispatch => {
        try {
            const res = await axios.get(URL);
            const filteredEmployees = filterEmployeesByManagementRole(user, res.data);
            dispatch({ type: actionType.GET_EMPLOYEES, data: filteredEmployees });
        } catch (error) {
            console.error(error);
        }
    }
}

export const FindEmployee = (user, name) => {
    return async dispatch => {
        try {
            const res = await axios.get(`${URL}/name=${name}`);
            const filteredEmployees = filterEmployeesByManagementRole(user, res.data);
            dispatch({ type: actionType.GET_EMPLOYEES, data: filteredEmployees });
        } catch (error) {
            console.error(error);
        }
    }
}

export const deleteEmployee = (EmployeeId) => {
    return async dispatch => {
        try {
            await axios.delete(`${URL}/${EmployeeId}`);
            Swal.fire({
                position: "top",
                icon: "success",
                title: "The employee has been marked as inactive",
                showConfirmButton: false,
                timer: 1000
            });
            dispatch({ type: actionType.DELETE_EMPLOYEE, data: EmployeeId });
        } catch (error) {
            Swal.fire({
                icon: "error",
                title: "Oops...",
                text: "Error deleting employee",
                footer: '<a href="#">Back to adding an employee?/a>'
            });
        }
    }
}

export const addEmployee = (data) => {
    return async dispatch => {
        try {
            const res = await axios.post(URL, data);
            dispatch({ type: actionType.ADD_EMPLOYEE, data: res.data });
            Swal.fire({
                position: "top",
                icon: "success",
                title: "The employee was successfully added",
                showConfirmButton: false,
                timer: 1500
            });
        } catch (error) {
            Swal.fire({
                icon: "error",
                title: "Oops...",
                text: "Adding employee failed",
                footer: '<a href="#">Back to adding an employee?</a>'
            });
        }
    }
}

export const editEmployee = (data) => {
    return async dispatch => {
        try {
            const res = await axios.put(`${URL}/${data.Id}`, { ...data });
            dispatch({ type: actionType.EDIT_EMPLOYEE, data: res.data });
            Swal.fire({
                position: "top",
                icon: "success",
                title: "The employee details have been updated successfully",
                showConfirmButton: false,
                timer: 1500
            });
        } catch (error) {
            Swal.fire({
                icon: "error",
                title: "Oops...",
                text: "Error editing employee",
                footer: '<a href="#">Back to employees/a>'
            });
        }
    }
}
