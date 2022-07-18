import axios from 'axios'
import {
    ADD_NEW_TOOL_USER_ROW,
    FETCH_ERROR,
    FETCH_START,
    FETCH_TOOL_SUCCESS,
    FETCH_TOOL_USER_SUCCESS,
    FETCH_USER_SUCCESS
} from './actionTypes'

export function fetchToolUser() {
    return async dispatch => {
        dispatch(fetchStart())
        try {
            const response = await axios.get('/ToolUser')
            const ToolUser = response.data
            dispatch(fetchToolUserSuccess(ToolUser))
        } catch (e) {
            dispatch(fetchError(e))
        }
    }
}

export function fetchStart() {
    return {
        type: FETCH_START
    }
}

export function fetchToolUserSuccess(ToolUser) {
    return {
        type: FETCH_TOOL_USER_SUCCESS,
        ToolUser: ToolUser
    }
}

export function fetchError(e) {
    return {
        type: FETCH_ERROR,
        error: e
    }
}

export function addNewToolUser() {
    return dispatch => {
        const NewToolUser = [];
        NewToolUser.push(
            {
                tool_id: '',
                countTools: '',
                user_id: ''
            }
        )
        dispatch(addNewToolUserRow(NewToolUser))
    }
}

export function addNewToolUserRow(NewToolUser) {
    return {
        type: ADD_NEW_TOOL_USER_ROW,
        NewToolUser: NewToolUser
    }
}

export function saveNewToolUser(NewToolUser) {
    return async dispatch => {
        await axios.post('/ToolUser', NewToolUser)
        dispatch(addNewToolUserRow([]))
        dispatch(fetchToolUser())
    }
}

export function cancelNewToolUser() {
    return async dispatch => {
        dispatch(addNewToolUserRow([]))
    }
}

export function fetchTool(value) {
    return async dispatch => {
        dispatch(fetchStart())
        try {
            const response = await axios.get(`/Tool/${value}`)
            const Tool = response.data
            dispatch(fetchToolSuccess(Tool))
        } catch (e) {
            dispatch(fetchError(e))
        }
    }
}

export function fetchToolSuccess(Tool) {
    return {
        type: FETCH_TOOL_SUCCESS,
        Tool: Tool
    }
}

export function fetchUser() {
    return async dispatch => {
        dispatch(fetchStart())
        try {
            const response = await axios.get('/User')
            const User = response.data
            dispatch(fetchUserSuccess(User))
        } catch (e) {
            dispatch(fetchError(e))
        }
    }
}

export function fetchUserSuccess(User) {
    return {
        type: FETCH_USER_SUCCESS,
        User: User
    }
}

export function deleteToolUser(id) {
    console.log(id)
    return async dispatch => {
        dispatch(fetchStart())
        try {
            await axios.delete(`/ToolUser/${id}`)
            dispatch(fetchToolUser())
        } catch (e) {
            dispatch(fetchError(e))
        }
    }
}
