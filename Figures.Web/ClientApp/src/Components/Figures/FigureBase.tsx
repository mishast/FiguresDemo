import React from 'react';

export interface FigureBaseProps {

}

export interface FigureBaseState
{
  result: String
}

export class FigureBase<P extends FigureBaseProps, S extends FigureBaseState> extends React.Component<P, S> {
    constructor(props: P) {
        super(props);

        this.setState({ result: 'n / a'});
    }

    makeRequest() : any
    {
        return {};
    }

    handleCalculate(event: React.MouseEvent<HTMLElement>) {
        event.preventDefault();

        console.log("handleCalculate!");

        let request = this.makeRequest();

        fetch('api/figures/calculateArea', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(request)
        })
        .then((response: any) => {
            if (response.ok)
            {
                response.json().then( (result: any) => {
                    console.log(result);
                    this.setState({"result": result.area});
                });
            }
            else
            {
                response.json().then( (result: any) => {
                    console.log(result);
                    this.setState({"result": "Error: " + result.error});
                });
            }
        });
    }

    render() {
        return <div></div>
    }
}

export default FigureBase