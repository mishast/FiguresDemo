import React from 'react';
import {FigureBaseProps, FigureBaseState, FigureBase} from './FigureBase'

interface TriangleProps extends FigureBaseProps {

}

interface TriangleState extends FigureBaseState {
  sideA: String,
  sideB: String,
  sideC: String
}

class Triangle extends FigureBase<TriangleProps, TriangleState> {
    state = 
    {
        sideA: '0',
        sideB: '0',
        sideC: '0',
        result: 'n / a'
    }

    handleChange(event: React.ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;

        if (name === "sideA")
        {
            this.setState({ sideA: value });
        }

        if (name === "sideB")
        {
            this.setState({ sideB: value });
        }

        if (name === "sideC")
        {
            this.setState({ sideC: value });
        }
        
    }

    makeRequest() : any {
        let request = {
            "figure": "triangle",
            "params": {
                "a": this.state.sideA,
                "b": this.state.sideB,
                "c": this.state.sideC
            }
        };

        return request;
    }

    render() {
        return <div>
         <div className="form-group">
            <label>Side A</label>
            <input type="text" name="sideA" className="form-control" onChange={(e) => this.handleChange(e)}></input>
        </div>
        <div className="form-group">
            <label>Side B</label>
            <input type="text" name="sideB" className="form-control" onChange={(e) => this.handleChange(e)}></input>
        </div>
        <div className="form-group">
            <label>Side C</label>
            <input type="text" name="sideC" className="form-control" onChange={(e) => this.handleChange(e)}></input>
        </div>
        <button type="submit" className="btn btn-primary" onClick={(e) => this.handleCalculate(e)}>Calculate</button>
        <div className="form-group result-group">
            <label>Result:</label>
            <div>{this.state.result}</div>
        </div>
        </div>
    }
}

export default  Triangle