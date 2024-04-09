import actions, * as actiontype from './actions'
const initialState = {
    roles: []
}
const RolesReducer = (state = initialState, action) => {
    switch (action.type) {
        case actiontype.SET_ROLES: {
            return { ...state, roles: action.data };
        }
        case actiontype.ADD_ROLE: {
            const roles = [...state.roles];
            roles.push(action.data);
            return { ...state, roles }
        }
        default: return { ...state };
    }

}
export default RolesReducer