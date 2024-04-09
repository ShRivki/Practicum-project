import axios from "axios";
import Swal from "sweetalert2";
import * as actiontype from '../store/actions';

const URL = 'https://localhost:7079/api/Role';

export const filterRolesByManagementRole = (user, roles) => {
    if (localStorage.getItem('isDirector') === "true") {
        return roles;
    }
    const userManagementRoles = user.roles.filter(role => role.isManagement);
    if (userManagementRoles.length === 0) {
        return [];
    }
    const filteredRoles = roles.filter(role => userManagementRoles.some(managedRole => managedRole.role.id === role.id));
    return filteredRoles;
}

export const getRoles = (user) => {
    return async dispatch => {
        try {
            const res = await axios.get(URL);
            dispatch({ type: actiontype.SET_ROLES, data: filterRolesByManagementRole(user, res.data) });
        } catch (error) {
            console.error(error);
        }
    }
}

export const addRole = (role) => {
    return async dispatch => {
        try {
            const res = await axios.post(URL, { Name: role.name, Star: role.star });
            dispatch({ type: actiontype.ADD_ROLE, data: res.data });
            Swal.fire({
                icon: "success",
                title: `${role.name} Added to the job list`,
                showConfirmButton: false,
                timer: 1000
            });
        } catch (error) {
            Swal.fire({
                icon: "error",
                title: `${error}: Add failed`,
                showConfirmButton: false,
                timer: 1000
            });
            console.error(error);
        }
    }
}
