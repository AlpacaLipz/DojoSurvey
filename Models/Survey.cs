#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace DojoSurvey.Models;
public class Survey
{
  [Required(ErrorMessage = "Name is required."),MinLength(2)]
  public string Name {get;set;}
  [Required(ErrorMessage = "Location is required.")]
  public string Location {get;set;}
  [Required(ErrorMessage = "Language is required.")]
  public string Language {get;set;}
  [MinLength(20)]
  public string? Comment {get;set;}
}