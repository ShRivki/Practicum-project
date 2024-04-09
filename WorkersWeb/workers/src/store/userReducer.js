import * as actiontype from './actions';

const initialState = {
  user: JSON.parse(localStorage.getItem('user'))
};

const UserReducer = (state = initialState, action) => {
  switch (action.type) {
    case actiontype.LOG_IN:
      return { ...state, user: action.data };
    case actiontype.LOG_OUT:
      localStorage.removeItem('user');
      localStorage.removeItem('isDirector');
      return { ...state, user: null };
    default: return { ...state };
  }
};

export default UserReducer;