using MAUIGameLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIGameLibrary.Services
{
    public class GameDataService
    {
        private List<GameInformation> _gameInformation = new List<GameInformation>();

        public List<GameInformation> GetAllInformation()
        {
            return _gameInformation;
        }

        public void UpdateGameinformation(GameInformation gameInformation)
        {
            if (!string.IsNullOrEmpty(gameInformation.Id))
            {
                var uniqueGame = GetGameInformationById(gameInformation.Id);

                int position = _gameInformation.IndexOf(uniqueGame);


                _gameInformation[position] = gameInformation;
            }
            else
            {
                _gameInformation.Add(gameInformation);
            }
        }


        public GameInformation GetGameInformationById(string id)
        {
            var uniqueGame = _gameInformation.Where(gameInfo => gameInfo.Id == id).FirstOrDefault();
            return uniqueGame;
        }

        public List<GameInformation> GetGameInformationByTitle(string title)
        {
            return _gameInformation.Where(gameInfo => gameInfo.Title == title).ToList();
        }
    }
}
