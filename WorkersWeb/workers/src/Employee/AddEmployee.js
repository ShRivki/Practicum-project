import { useForm, useFieldArray } from "react-hook-form"
import { yupResolver } from "@hookform/resolvers/yup"
import * as yup from "yup"
import { useLocation } from "react-router-dom"
import { useDispatch, useSelector } from "react-redux"
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Button } from 'semantic-ui-react';
import { addEmployee, editEmployee } from '../services/employeeService'
import { getRoles, addRole } from '../services/rolesService'
import '../App.css'
const schema = yup.object().shape({
    firstName: yup.string().required('Required field').matches(/^[a-zA-Z ]{2,}$/, 'שם חייב להכיל לפחות 3 תווים ולהכיל אותיות באנגלית בלבד'),
    lastName: yup.string().required('Required field').matches(/^[a-zA-Z ]{2,}$/, 'שם חייב להכיל לפחות 3 תווים ולהכיל אותיות באנגלית בלבד'),
    identity: yup.string().required('Required field').matches(/^\d{9}$/, 'תעודת הזהות חייבת להכיל 9 ספרות בדיוק'),
    startDate: yup.date().required('Required field').min(yup.ref('dateOfBirth'), 'תאריך תחילת העבודה חייב להיות לאחר תאריך הלידה'),
    dateOfBirth: yup.date().required('Required field'),
    password: yup.string().required('Required field').min(6, 'הסיסמה חייבת להכיל לפחות 6 תווים').matches(/(?=.*[a-z])/, 'הסיסמה חייבת לכלול לפחות אות קטנה אחת')
        .matches(/(?=.*[A-Z])/, 'הסיסמה חייבת לכלול לפחות אות גדולה אחת')
        .matches(/(?=.*[0-9])/, 'הסיסמה חייבת לכלול לפחות מספר אחד'),
    gender: yup.number(),
    roles: yup.array().of(yup.object().shape({
        role: yup.object().shape({
            id: yup.number().nullable(),
            name: yup.string().nullable()
        }).nullable(),
        isManagement: yup.boolean().nullable(),
        startDate: yup.date().required('Required field').min(yup.ref('startDate'), 'תאריך תחילת העבודה חייב להיות לאחר תאריך תחילת העבודה'),
    }))
});
export default () => {
    const navigate = useNavigate();
    const { state } = useLocation();
    const { user, roles } = useSelector(state => ({
        user: state.User.user,
        roles: state.Roles.roles,
    }));
    const dispatch = useDispatch();
    const onSubmit = (data) => {
        var list = []
        data.roles.forEach(role => {
            alert(role.role.id);
            var a = { "roleId": role.role.id, "startDate": role.startDate, "isManagement": role.isManagement }
            list.push(a)
        });
        data.roles = list;
        const employee = { ...data, active: state?.active || true, Id: state?.id };
        state !== null && dispatch(editEmployee((employee))) || state == null && dispatch(addEmployee(employee));
        navigate('/EmployeeList');
    }
    const {
        register,
        handleSubmit,
        formState: { errors },
        control
    } = useForm({
        resolver: yupResolver(schema),
        defaultValues: {
            firstName: state?.firstName,
            lastName: state?.lastName,
            identity: state?.identity,
            password: state?.password,
            startDate: state?.startDate.split('T')[0],
            dateOfBirth: state?.dateOfBirth.split('T')[0],
            gender: state?.gender,
            roles: state?.roles.map(role => ({
                ...role,
                startDate: role.startDate.split('T')[0]
            })) || [],
        }
    })
    const { fields, append, remove } = useFieldArray({
        control,
        name: "roles",
    });
    const [roleSelected, setRoleSelected] = useState([]);
    useEffect(() => {
        handleRoleChange();
    }, []);
    function handleRoleChange() {
        const rolesId = [];
        fields.map((x) => { rolesId.push(+x.role.id); })
        console.log(rolesId);
        setRoleSelected(rolesId)
    }
    const [dateStartWork, SetdateStartWork] = useState(state?.startDate.split('T')[0]);
    const [role, SetRole] = useState({ "name": "" });
    useEffect(() => {
        dispatch(getRoles(user));
    }, [role]);
    function generateInputField(label, registerName, iconName, type = 'text') {
        return (
            <div className="field">
                <label>{label}:</label>
                <div className="ui right icon input">
                    <input type={type} placeholder={label} {...register(registerName)} />
                    <i className={`${iconName} icon`}></i>
                </div>
                {errors[registerName] && <p className="ui pointing red basic label">{errors[registerName]?.message}</p>}
            </div>
        );
    }
    return <div className="square-box edit">
        <br />
        <button className="close-button" onClick={() => navigate("/EmployeeList")}><i className="window close icon"></i></button>
        {localStorage.getItem('isDirector') == "true" && (
            <div id="form">
                <input type="text" placeholder="enter role" name="role" onChange={(event) => {
                    SetRole(prevRole => ({ ...prevRole, name: event.target.value }));
                }} />
                <button className="button but" onClick={() => {
                    dispatch(addRole(role));
                }}>הוסף תפקיד</button>
            </div>
        )}
        <div id="container">
            <div id="form" className="ui placeholder segment">
                <form onSubmit={handleSubmit(onSubmit)}>
                    <div className="ui one column very relaxed stackable grid">
                        <div className="column">
                            <div className="ui form">
                                <div>
                                    {generateInputField("firstName:", "firstName", "user")}
                                    {generateInputField("lastName:", "lastName", "user")}
                                    {generateInputField("identity:", "identity", "address book outline")}
                                    {generateInputField("password:", "password", "lock", "password")}
                                    {generateInputField("birthDate:", "dateOfBirth", "calendar alternate outline", "date")}
                                    <div className="field">
                                        <label>startDate:</label>
                                        <div className="ui rigth icon input">
                                            <input placeholder="startDate" {...register("startDate")} type="date" onChange={(event) => SetdateStartWork(event.target.value)} />
                                            <i className="calendar alternate outline icon"></i>
                                        </div>
                                        {errors.startDate && <p className="ui pointing red basic label">{errors.startDate?.message}</p>}
                                    </div>
                                    <div className="field">
                                        <label>gender:</label>
                                        <select id="gender" {...register("gender")}>
                                            <option value={1}>male</option>
                                            <option value={2}>female</option>
                                        </select>
                                    </div>
                                </div>
                                <div>
                                    <h2>תפקידים:</h2>
                                    {fields.map((x, i) =>
                                        <div key={i} id="card">
                                            <div className="field">
                                                <label>{i + 1} role:</label>
                                                <div>
                                                    <button onClick={() => { remove(i); handleRoleChange() }}><i className="trash icon"></i></button>
                                                    <select {...register(`roles[${i}].role.id`)} defaultValue={state?.roles[i]?.role?.id || ""} onChange={(e) => handleRoleChange()}>
                                                        {roles.map((x) => {
                                                            const isRoleSelected = roleSelected.includes(x.id);
                                                            return (<option key={x.id} value={x.id} disabled={isRoleSelected}> {x.name} </option>);
                                                        })}
                                                    </select>
                                                </div>
                                            </div>
                                            {generateInputField("Management:", `roles[${i}].isManagement`, "mail ", "checkbox")}
                                            <div className="field">
                                                <label>startDate:</label>
                                                <div className="ui input">
                                                    <input placeholder="startDate" min={dateStartWork} type="date" {...register(`roles[${i}].startDate`)} />
                                                    {errors?.roles && errors.roles[i]?.startDate && <p className="ui pointing red basic label">{errors.roles[i].startDate?.message}</p>}
                                                </div>
                                            </div>
                                        </div>, <br />
                                    )}<button className="button but" onClick={(e) => { e.preventDefault(); append({}); handleRoleChange() }}>add role</button>
                                </div>, <br />
                                <button type="submit" className="button but" >save employee</button>
                            </div>
                        </div>
                    </div>
                </form >
            </div>
        </div>
    </div>
}