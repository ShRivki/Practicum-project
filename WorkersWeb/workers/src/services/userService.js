import axios from "axios";
import Swal from "sweetalert2";
import * as actionType from '../store/actions';

const URL = 'https://localhost:7079/api/Employee';

export const logIn = (data, navigate) => {
    return async dispatch => {
        try {
            const response = await axios.post(`${URL}/Login`, { Name: data.UserName, Password: data.Password });
            const user = response.data;

            dispatch({ type: actionType.LOG_IN, user });
            localStorage.setItem("user", JSON.stringify(user));
            const isDirector = user.roles.some(role => role.role.name === "Director");
            localStorage.setItem("isDirector", isDirector ? "true" : "false");
            navigate("/");

            Swal.fire({
                position: "top",
                title: `${user.firstName} Hello to `,
                showConfirmButton: false,
                timer: 1500
            });

            setTimeout(function() {
                window.location.reload();
            }, 1300);
        } catch (error) {
            console.log(error.message);

            Swal.fire({
                position: "top",
                title: `You are not registered in the system ${error.message}`,
                showConfirmButton: false,
                timer: 1500
            });
        }
    };
};

export const logOut = (navigate) => {
    return dispatch => {
        Swal.fire({
            title: "Oops...",
            showCancelButton: true,
            showDenyButton: false,
            confirmButtonText: "go out",
            cancelButtonText: "cancel",
        }).then((r) => {
            if (r.isConfirmed) {
                dispatch({ type: actionType.LOG_OUT });
                Swal.fire({
                    title: "By By:)", showConfirmButton: false,
                    timer: 800
                });
            }
            navigate("/HomePage")
        });
    };
};

export const signIn = (data, navigate) => {
    return async dispatch => {
        try {
            const response = await axios.post(URL, data);
            const user = response.data;

            dispatch({ type: actionType.LOG_IN, user });
            Swal.fire({
                position: "top",
                title: `${user.Name} The employee was successfully added`,
                showConfirmButton: false,
                timer: 1500
            });
            navigate("/");
        } catch (error) {
            Swal.fire({
                position: "top",
                title: "This employee is registered in the system!",
                showConfirmButton: false,
                timer: 1500
            });
            navigate("/HomePage");
        }
    };
};
