import React, {Component} from 'react';
import {connect} from "react-redux";
import {
    addNewToolUser,
    cancelNewToolUser,
    deleteToolUser,
    fetchTool,
    fetchToolUser,
    fetchUser,
    saveNewToolUser
} from "../../store/actions/toolUser";
import Select from "../UI/Select/Select";

class ToolUserList extends Component {

    state = {
        selectedToolId: 1,
        selectedToolCount: 0,
        selectedUserId: 1
    }

    selectToolIdHandler = event => {
        this.setState({
            selectedToolId: +event.target.value
        })
    }

    selectToolCountHandler = event => {
        this.setState({
            selectedToolCount: +event.target.value
        })
        this.props.fetchTool(+event.target.value)
    }

    selectUserIdHandler = event => {
        this.setState({
            selectedUserId: +event.target.value
        })
    }

    saveClickHandler = () => {
        const newToolUserr = {
            tool_id: this.state.selectedToolId,
                countTools: this.state.selectedToolCount,
            user_id: this.state.selectedUserId
        }
        this.props.saveNewToolUser(newToolUserr)
    }

    renderToolUser() {
        return this.props.toolUser.map(
            (row, index) => {
                return (
                    <tr key={index}>
                        <th scope="row">{index + 1}</th>
                        <td>{row.tool.name}</td>
                        <td>{row.countTools}</td>
                        <td>{row.user.name}</td>
                        <td>
                            <button
                                className="btn btn-sm btn-danger"
                                onClick={() => this.props.deleteToolUser(row.id)}
                            >Удалить
                            </button>
                        </td>
                    </tr>
                )
            }
        )
    }

    renderNewToolUser() {
        return this.props.newToolUser.map(
            row => {
                return (
                    <tr className="table-info" key={this.props.toolUser.length + 1}>
                        <th scope="row">{this.props.toolUser.length + 1}</th>
                        <td>
                            <Select
                                value={this.state.selectedToolId}
                                onChange={this.selectToolIdHandler}
                                options={this.props.tool}
                            />
                        </td>
                        <td>
                            <input className="form-control" type="number" min="1"
                                   value={this.state.selectedToolCount}
                                   onChange={this.selectToolCountHandler}
                            />
                        </td>
                        <td>
                            <Select
                                value={this.state.selectedUserId}
                                onChange={this.selectUserIdHandler}
                                options={this.props.user}
                            />
                        </td>
                        <td className="col-md-3">
                            <button
                                className="btn btn-sm btn-success"
                                onClick={this.saveClickHandler}
                            >Сохранить
                            </button>
                            <button
                                className="btn btn-sm btn-danger"
                                onClick={() => this.props.cancelNewToolUser()}
                            >Отмена
                            </button>
                        </td>
                    </tr>
                )
            }
        )
    }

    componentDidMount() {
        this.props.fetchToolUser();
        this.props.fetchUser();
    }

    render() {

        return (
            <div className="align-content-center">
                <button className="mt-5 mb-3 btn btn-sm btn-success" onClick={this.props.addNewToolUser}>Добавить
                    запись
                </button>
                <table className="table">
                    <thead>
                    <tr className="table-primary">
                        <th scope="col">#</th>
                        <th scope="col">Название инструмента</th>
                        <th scope="col">Количество</th>
                        <th scope="col">Имя держателя</th>
                    </tr>
                    </thead>
                    <tbody>
                    {this.renderToolUser()}
                    {this.renderNewToolUser()}
                    </tbody>
                </table>
            </div>
        )
    }
}

// Map Redux state to component props
function mapStateToProps(state) {
    return {
        toolUser: state.toolUser.ToolUser,
        newToolUser: state.toolUser.NewToolUser,
        user: state.toolUser.User,
        tool: state.toolUser.Tool
    }
}

// Map Redux actions to component props
function mapDispatchToProps(dispatch) {
    return {
        fetchToolUser: () => dispatch(fetchToolUser()),
        addNewToolUser: () => dispatch(addNewToolUser()),
        saveNewToolUser: (NewToolUser) => dispatch(saveNewToolUser(NewToolUser)),
        fetchTool: (value) => dispatch(fetchTool(value)),
        fetchUser: () => dispatch(fetchUser()),
        deleteToolUser: (id) => dispatch(deleteToolUser(id)),
        cancelNewToolUser: () => dispatch(cancelNewToolUser())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ToolUserList)