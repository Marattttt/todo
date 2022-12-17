using System.ComponentModel.DataAnnotations;

namespace Todo.Models;
class Admin : User
{
    private String? _safeWord { get; }
    
    public bool Authenticate (string safeWord)
    {
        if (_safeWord is null)
            return true;
        
        return safeWord == _safeWord;
    }
}