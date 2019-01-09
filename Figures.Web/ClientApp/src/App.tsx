import React from 'react';
import FigureForm from './Components/FigureForm'
import './Styles/App.css'

interface AppProps {

}

interface AppState
{
  figureOpts: React.ReactNode,
  selectedFigure: String,
  result: String
}

class App extends React.Component<AppProps, AppState> {
  state = 
  {
    figureOpts: [<option key="none" value="none">Loading...</option>],
    selectedFigure: 'none',
    result: ''
  }

  constructor(props: AppProps)
  {
    super(props);

    fetch('api/figures/getAvailableFigures')
    .then(respone => respone.json())
    .then((data: any) => {

      let figureOpts : React.ReactNode[] = [];

      figureOpts.push(<option key="none" value="none">Select figure...</option>);

      for (var i = 0; i < data.length; i++) {
        figureOpts.push(<option key={data[i]} value={data[i]}>{data[i]}</option>);
      }

      this.setState({figureOpts: figureOpts});
    });
  }

  handleSelectFigure(event : React.ChangeEvent<HTMLSelectElement>) {
    this.setState({selectedFigure: event.target.value});
  }

  render() {
    return (
      <div className="container main-container">
        <div className="card">
          <div className="card-body">
            <h5 className="card-title">Area calculator</h5>
            <div className="card-text">
              <form>
                <div className="form-group">
                  <label>Figure</label>
                  <select id='figure-select' className="form-control" onChange={(e) => this.handleSelectFigure(e)}>
                    {this.state.figureOpts}
                  </select>
                </div>
                <FigureForm figure={this.state.selectedFigure}></FigureForm>
              </form>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default App;
