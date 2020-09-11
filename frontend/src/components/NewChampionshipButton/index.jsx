import React, { Component }  from 'react';
import './styles.css';
import { apiURL } from '../../api/api';

export default class NewChampionshipButton extends Component{
    
    constructor(props){
        super(props);

        this.state = {
            hide: false
        };
    }

    StartNewChampionship = async () => {

        if(this.props.selectedMovies.length === 8){
            const response = await fetch(apiURL.championship, {
                method: "POST", 
                body: JSON.stringify(this.props.selectedMovies), 
                headers: { 
                    "Content-type": "application/json; charset=UTF-8"
                }
            });
    
            const responseModels = await response.json();
    
            this.props.onChampionshipStart(responseModels);
    
            this.setState({hide: true});
        }
    };
    
    render() {

        const style = this.state.hide ? {display: 'none'} : {}

        return(
            <button id="btn-new-championship" onClick={this.StartNewChampionship} style={style}>GERAR MEU CAMPEONATO</button>
        );
    };

};