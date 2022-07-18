import React from 'react';
import ReactDOM from 'react-dom/client';
import {Provider} from 'react-redux'
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import {store} from "./store";
import {compose} from "redux";

const composeEnhancers =
    typeof window === 'object' &&
    window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ ?
        window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__({
        }) : compose;

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <Provider store={store}>
            <App />
    </Provider>
);

reportWebVitals();
