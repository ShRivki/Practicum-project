import { createStore, combineReducers, applyMiddleware } from 'redux';
import { thunk } from 'redux-thunk'
import rolesReducer from './rolesReducer';
import userReducer from './userReducer';
import employeesReducer from './employeeReducer';
const reducers = combineReducers({
    User: userReducer,
    Roles: rolesReducer,
    Employee: employeesReducer
})
export const store = createStore(reducers, applyMiddleware(thunk));