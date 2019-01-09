import React from 'react';
import {FigureBaseProps, FigureBaseState, FigureBase} from './FigureBase'

interface CircleProps extends FigureBaseProps{

}

interface CircleState extends FigureBaseState
{
  radius: String
}

class Circle extends FigureBase<CircleProps, CircleState> {
    state = 
    {
        radius: '0',
        result: 'n / a'
    }

    handleChange(event: React.ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;

        if (name === "radius")
        {
            this.setState({ radius: value });
        }
    }

    makeRequest() : any
    {
        let request = {
            "figure": "circle",
            "params": {
                "radius": this.state.radius
            }
        };

        return request;
    }

    render() {
        return <div>
         <div className="form-group">
            <label>Radius</label>
            <input type="text" name="radius" className="form-control" onChange={(e) => this.handleChange(e)}></input>
        </div>
        <button type="submit" className="btn btn-primary" onClick={(e) => this.handleCalculate(e)}>Calculate</button>
        <div className="form-group result-group">
            <label>Result:</label>
            <div>{this.state.result}</div>
        </div>
        </div>
    }
}

export default  Circle