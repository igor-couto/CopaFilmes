import React, { Component } from 'react';
import { Header } from './components/Header';
import { PageContent } from './components/PageContent';

export default class App extends Component{

  constructor(props){
    super(props);

    this.onChampionshipStart = this.onChampionshipStart.bind(this);

    this.state = {
      championshipHasStarted: false,
      winners: []
    };
  }

  onChampionshipStart(winners){
    this.setState({
      championshipHasStarted: true,
      winners: winners
    });
  }

  render(){
    return (
      <div className="App">

          <Header 
            championshipHasStarted={this.state.championshipHasStarted}           
          />

          <PageContent 
            onChampionshipStart={this.onChampionshipStart}
            winners={this.state.winners}
          />

      </div>
    );
  }
}