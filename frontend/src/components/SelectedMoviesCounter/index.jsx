import React, {Component} from 'react';
import './style.css';

export class SelectedMoviesCounter extends Component{

    constructor(props){
        super(props);
    }

    render(){
        if(this.props.winners === null || this.props.winners.length === 0)
        {
            return (
                <div id="movie-counter">
                    <div>Selecionados</div>
                    <div>{this.props.selected} de {this.props.total} filmes </div>
                </div>
            )
        }else{
            return(null);
        }
    }
}