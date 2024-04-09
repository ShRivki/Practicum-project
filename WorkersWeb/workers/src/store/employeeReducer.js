import * as actiontype from './actions'
const initialState = {
    employees: []
}
const EmployeesReducer = (state = initialState, action) => {
    switch (action.type) {
        case actiontype.GET_EMPLOYEES:
            return { ...state, employees: action.data }
        case actiontype.ADD_EMPLOYEE: {
            const employees = [...state.employees];
            employees.push(action.data);
            return { ...state, employees }
        }
        case actiontype.EDIT_EMPLOYEE: {
            const employees = [...state.employees];
            const findIndex = employees.findIndex(x => x.id === action.data.id);
            console.log(employees[findIndex]);
            employees[findIndex] = action.data;
            console.log(employees[findIndex]);
            return { ...state, employees }
        }
        case actiontype.DELETE_EMPLOYEE: {
            const employees = state.employees.filter(x => x.id !== action.data)
            return { ...state, employees }
        }
        default: return { ...state }
    }
}

export default EmployeesReducer;