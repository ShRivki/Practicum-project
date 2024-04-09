import React from "react";
import { useLocation } from "react-router-dom";
import { Button } from "semantic-ui-react";
import { useNavigate } from "react-router-dom";
import { formatDateString } from "./EmployeeList";
import "../App.css";

const RoleItem = ({ role }) => {
    return (
        <tr>
            <td>{role.role.name}</td>
            <td>{formatDateString(role.startDate)}</td>
            <td>{role.isManagement ? <i className="check icon"></i> : <i className="x icon"></i>}</td>
        </tr>
    );
};
const EmployeeDetails = () => {
    const navigate = useNavigate();
    const { state } = useLocation();
    const { firstName, lastName, identity, startDate, roles } = state;

    return (
        <div className="square-box">
            <button className="close-button" onClick={() => navigate("/EmployeeList")}><i className="window close icon"></i></button>
            <div className="employee-details">
                <div className="employee-info">
                    <label className="employee-label">Name:</label>
                    <p className="employee-value">{firstName} {lastName}</p>
                </div>
                <div className="employee-info">
                    <label className="employee-label">Identity:</label>
                    <p className="employee-value">{identity}</p>
                </div>
                <div className="employee-info">
                    <label className="employee-label">Start Date:</label>
                    <p className="employee-value">{formatDateString(startDate)}</p>
                </div>
            </div>

            <br />
            <div className="table-container">
                <div
                    id="taitel"
                    className="ui horizontal divider header "
                    style={{ fontSize: "24px", color: "rgb(19 23 122)" }}
                >
                    Roles
                </div>
                <br />
                <table>
                    <thead>
                        <tr>
                            <th>Role Name</th>
                            <th>Start Date</th>
                            <th>Is Management</th>
                        </tr>
                    </thead>
                    <tbody>
                        {roles.map((role, index) => (
                            <RoleItem key={index} role={role} />
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default EmployeeDetails;
