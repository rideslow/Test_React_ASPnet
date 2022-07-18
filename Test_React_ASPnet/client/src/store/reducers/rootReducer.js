import {combineReducers} from "redux";
import toolUserReducer from "./toolUser";

export const rootReducer = combineReducers({
            toolUser: toolUserReducer
        })