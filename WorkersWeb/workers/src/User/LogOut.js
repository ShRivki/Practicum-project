import { useEffect } from 'react'
import { logOut } from '../services/userService'
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
export default () => {
    const navigate = useNavigate();
    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(logOut(navigate))
    }, []);
    return null;
}
