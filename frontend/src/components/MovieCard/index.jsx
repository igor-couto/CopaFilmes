import React, { Component } from 'react';
import './style.css';

export class MovieCard extends Component {
    
    constructor(props){
        super(props);

        this.state = {
            movie: props.movie,
            isSelected: false
        };
    }

    onClick = () => {
        const newSelection = !this.state.isSelected;

        const canSelect = this.props.onCardSelect(newSelection, this.state.movie);

        if(canSelect){
            this.setState({ 
                isSelected: newSelection 
            });
        }
    };
    
    render(){
        return (
            <div id={this.state.movie.id} className="movie-card" onClick={this.onClick}>
                <div className="movie-checkbox">
                    <input type="checkbox"
                    checked={this.state.isSelected}
                    onChange={() => {}}
                    />
                </div>
                
                <div>
                    <div className="movie-title">{this.state.movie.titulo}</div>
                    <div className="movie-year">{this.state.movie.ano}</div>
                </div>
                
            </div>
        );
    }

}