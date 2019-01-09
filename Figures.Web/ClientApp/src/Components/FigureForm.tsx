import React from 'react';
import Circle from './Figures/Circle'
import Triangle from './Figures/Triangle'

interface FigureFormProps
{
    figure: String
}

interface FigureFormState
{

}

class FigureForm extends React.Component<FigureFormProps, FigureFormState> {
    render() {
        if (this.props.figure === "circle") {
            return <Circle></Circle>
        } else if (this.props.figure === "triangle") {
            return <Triangle></Triangle>
        } else if (this.props.figure === "none") {
            return <div></div>
        } else {
            return <div>For this figure doesn't exists view</div>
        }
    }
}

export default  FigureForm