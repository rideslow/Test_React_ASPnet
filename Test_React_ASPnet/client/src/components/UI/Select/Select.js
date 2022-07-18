import React from 'react'

const Select = props => {
    const htmlFor = `${Math.random()}`

    return (
        <div>
            <select
                className="form-select"
                id={htmlFor}
                value={props.value}
                onChange={props.onChange}
            >
                { props.options.map((option, index) => {
                    return (
                        <option
                                value={option.id}
                                key={Math.random() + index}
                            >
                                {option.name}
                            </option>
                    )
                }) }
            </select>
        </div>
    )
}

export default Select