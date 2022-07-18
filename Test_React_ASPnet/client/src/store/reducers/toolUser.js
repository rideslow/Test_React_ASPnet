import {
    ADD_NEW_TOOL_USER_ROW,
    FETCH_ERROR,
    FETCH_START,
    FETCH_TOOL_SUCCESS,
    FETCH_TOOL_USER_SUCCESS,
    FETCH_USER_SUCCESS
} from '../actions/actionTypes';

const initialState = {
    ToolUser: [],
    NewToolUser: [],
    Tool: [],
    User: [],
    loading: false,
    error: null
}

export default function toolUserReducer(state = initialState, action) {
    switch (action.type) {
        case FETCH_START:
            return {
                ...state, loading: true
            }
        case FETCH_TOOL_USER_SUCCESS:
            return {
                ...state, loading: false, ToolUser: action.ToolUser
            }
        case FETCH_ERROR:
            return {
                ...state, loading: false, error: action.error
            }
        case ADD_NEW_TOOL_USER_ROW:
            return {
                ...state, NewToolUser: action.NewToolUser
            }
        case FETCH_TOOL_SUCCESS:
            return {
                ...state, loading: false, Tool: action.Tool
            }
        case FETCH_USER_SUCCESS:
            return {
                ...state, loading: false, User: action.User
            }
        default:
            return state
    }
}